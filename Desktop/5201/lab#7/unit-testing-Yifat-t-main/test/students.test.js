import { expect } from 'chai';
import { students } from '../src/students.js';

describe('students array', () => {
    it('should include my name', () => {
        expect(students).to.be.an('array');
        expect(students.includes('Yifat Tshuva')).to.be.true
        //expect(students).to.be.an('array').and.to.include('Yifat Tshuva'); // anothe option
        
    });
    
    
});