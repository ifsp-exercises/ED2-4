const rawData = {
  title: "Game boladao",
  price: null,
  year: 2077,
};

const game = {
  title: "GAme",
  price: 200,
  year: 2010,
};

const preparedData = Object.keys(rawData).reduce((accumulator, current) => {
  return {
    ...accumulator,
    ...(rawData[current]
      ? {
          [current]: rawData[current],
        }
      : {}),
  };
}, {});

const result = Object.assign(game, preparedData);

console.log(result);
