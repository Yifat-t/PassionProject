/**
 *  Randomize students, and pair them up.
 * 	If there is an odd number of students,
 * 	put the last three students in a group
 * 	of three.
 **/

import { students } from './students.js';

const shuffled = students
  .map((a) => ({sort: Math.random(), value: a}))
  .sort((a, b) => a.sort - b.sort)
  .map((a) => a.value);

const partners = [];

shuffled.forEach((student, index) => {
	const indexAtOne = index + 1;
	if (indexAtOne % 2 !== 0 && students[indexAtOne] !== undefined) {
		const newArr = [student, students[indexAtOne]];
		partners.push(newArr);	
	} else if (indexAtOne % 2 !== 0 && students[indexAtOne] === undefined) {
		partners[partners.length -1].push(student);
	}
});

export { partners };