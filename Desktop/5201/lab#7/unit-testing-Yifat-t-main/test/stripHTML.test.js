import { expect } from 'chai';
import { stripHTML } from '../src/stripHTML.js ';

describe('stripHTML', () => {
    it('html blockof text without tags', () => {
        const testHTML = '<h1>Hello,</h1> how are you today?<img src="my-image.jpg"/>';
        expect(stripHTML(testHTML)).to.equal("Hello, how are you today?");
    });
    
    
});