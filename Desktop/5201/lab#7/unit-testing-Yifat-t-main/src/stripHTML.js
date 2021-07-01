const stripHTML = (input) => input.replace(/(<([^>]+)>)/gi, "");

export {stripHTML};