import { students } from './students.js';

const studentCheck = () => (new Set(students)).size === students.length;

export { studentCheck };