import { expect } from 'chai';
import { studentCheck } from '../src/doesStudentDuplicateExist.js';
//

describe('mySuiteName', () => {
    it('return true when no duplicate students in the array', () => {
        expect(studentCheck()).to.be.true
    });
    
    
});