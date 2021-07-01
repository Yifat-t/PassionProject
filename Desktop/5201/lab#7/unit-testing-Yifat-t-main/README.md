# mocha

1. Install mocha & chai via npm

2. Write five tests. The names and locations of your tests files are described in the `package.json` file under the individual test scripts.

(You do not have to run the individual tests on your local - as you can see, there is a script called `test` that will run all tests if they're in the correct folder for that sort of thing. Also, it's not relevant what order the tests run.)

For each test: 
- import the `expect` assertion library, 
- import the exported function (or array, or whatever) that you want to test
- create a test suite that describes what you're testing
- create a test case that describes what your test is testing for

2a. Your first test should import the `studentCheck` function from `doesStudentDuplicateExist.test.js`. Test the result of the `studentCheck` function to ensure that it is true that there are no duplicates in the students array.

2b. Your next test should import the `stripHTML` function from `stripHTML.js`. Test the assertion that the function should remove HTML tags from a string. Provide a string containing HTML tags (including opening and closing tags, self-closing tags, and attributes) to the function, and expect the result to be a string, and to be equal to whatever text is in the provided string.

2c. Your third test should import the `aroc` function from `alphabetize.js`. The function should order an array alphabetically, regardless of case. Invoke the function, providing as a parameter an array for the function to alphabetize. Expect the first item in the array to be a string, and that it is equal to whatever string from the provided array ought to be first.

**Note**: Don't forget that if your string contains double-quotes, it should be wrapped in single quotes, or vice-versa.

2d. Your fourth test should import the `students` array from `students.js`. It should be an array, and it should include your name.

2e. Your final test should import the `students` array from `students.js` *and* the `partners` array from `partners.js`. Because of how the `partners` function works, we should expect the length of the partners array to be equal to half the length of the students array, rounded down to the nearest even number. Rather than make you figure out how to do that in JavaScript, I've already created `partners.test.js` and provided a function that can do that for you.

## Extra exercises

Try a little TDD - write a test that expects a lowercased string from a function provided a mixed-case string. Then, write your function in a file in the `src` folder. Run `npm test` and watch your test pass! Try this with other tests and functions, too.

-----

**Notes**: 

- Remember, to test the result of a function, you must invoke the function. In other words, don't forget to add parentheses (and parameters, if necessary) after the name of the function.
- All the assertions you need for this assignment are documented in the [Chai BDD API docs](https://www.chaijs.com/api/bdd/).