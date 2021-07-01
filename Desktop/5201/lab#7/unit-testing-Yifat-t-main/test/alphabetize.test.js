import { expect } from 'chai';
import { aroc } from '../src/alphabetize.js';

//

describe('aroc', () => {
    it('should alphabetize an arrary regardless of casing', () => {
        const myArray = ['Yifat' , 'tshuva'];
        //console.log(aroc(myArray)[0]);
        expect(aroc(myArray)[0]).to.equal('tshuva');
    });
    

});