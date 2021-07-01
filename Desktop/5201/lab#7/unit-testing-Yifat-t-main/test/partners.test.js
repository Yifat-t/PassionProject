import { expect } from 'chai';
import { students } from '../src/students.js';
import { partners } from '../src/partners.js';

// Put your other imports here.

/**
 *	Use this function to divide a number in half,
 * 	and round down to the nearest even number.
**/
const roundDownToEven = (n) => Math.floor(n / 2);

describe('partners', () => {
    it('have a length equal to students array divided in 2 and round down to the nearest number', () => {
        expect(partners.length).to.equal(roundDownToEven(students.length));
    });
    
    
});