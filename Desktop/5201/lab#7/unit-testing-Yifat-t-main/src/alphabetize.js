/**
*  Javascript's `sort()` function will order 
*  capital letters before lowercase letters.
*  This function will alphabetize array items
*  regardless of casing.
**/

const aroc = (list) => {
    list.sort((a, b) => {
        return a.toLowerCase().localeCompare(b.toLowerCase());
    });
    return list;
};

export { aroc };