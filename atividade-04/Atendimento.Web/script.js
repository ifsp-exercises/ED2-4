const apiBaseURL = "http://localhost:5000";

const observable = (initialValue) => {
  const observers = [];

  return {
    value: initialValue || "",
    subscribe: (fn) => observers.push(fn) - 1,
    unsubscribe: (index) => observers.splice(index, 1),
    next(nextValue) {
      this.value = nextValue;
      observers.forEach((observer) => observer(nextValue));
    },
  };
};

// Senhas

const senhas = observable([]);

const renderSenhas = senhas.subscribe(() => {
  const senhasTextArea = document.querySelector('textarea[name="senhas"]');

  const text = senhas.value.map((senha) => senha.dadosParciais).join("\n");

  senhasTextArea.value = "";
  senhasTextArea.value = text;
});

// Guiches

const guiches = observable([]);

const renderQuantidadeGuiches = guiches.subscribe(() => {
  document.querySelector('strong[name="qtd-guiches"]').textContent =
    guiches.value.length;
});

const renderGuichesSelect = guiches.subscribe(() => {
  const optionGroup = document.querySelector("#guiche-select > optgroup");

  while (optionGroup.firstChild) optionGroup.removeChild(optionGroup.lastChild);

  guiches.value.forEach((guiche) => {
    const optionElement = document.createElement("option");
    optionElement.value = guiche.id;
    optionElement.innerHTML = guiche.id;

    optionGroup.append(optionElement);
  });
});

const atendimentos = observable({});

const renderAtendimentos = atendimentos.subscribe(() => {
  const atendimentosTextArea = document.querySelector(
    'textarea[name="atendimentos"]'
  );

  let array = [];

  Object.keys(atendimentos.value).forEach((key) => {
    atendimentos.value[key].forEach((atendimento) => {
      array.push(atendimento.dadosCompletos);
    });
  });

  let text = array.join("\n");

  atendimentosTextArea.value = "";
  atendimentosTextArea.value = text;

  senhas.next(
    senhas.value
      .reverse()
      .slice(0, senhas.value.length - 1)
      .reverse()
  );
});

document
  .querySelector('button[name="generate-key-button"]')
  .addEventListener("click", (e) => {
    fetch(`${apiBaseURL}/senha`, { method: "POST" })
      .then((response) => response.json())
      .then((data) => senhas.next([...senhas.value, data]));
  });

document
  .querySelector('button[name="add-guiche-button"]')
  .addEventListener("click", (e) => {
    fetch(`${apiBaseURL}/guiche`, { method: "POST" })
      .then((response) => response.json())
      .then((data) => guiches.next([...data]));
  });

document
  .querySelector('button[name="call-key-button"]')
  .addEventListener("click", (e) => {
    const guicheEscolhido = document.querySelector("#guiche-select").value;

    if (guicheEscolhido == 0) return alert("Escolha um guichê");

    fetch(`${apiBaseURL}/guiche/${guicheEscolhido}`, {
      "Content-Type": "application/json",
      method: "PUT",
    })
      .then((response) => response.json())
      .then((data) =>
        atendimentos.next({
          ...atendimentos.value,
          [data.id]: data.atendimentos,
        })
      );
  });
