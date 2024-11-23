# **Web Testing Using C# and Selenium**

This project demonstrates automated testing of input fields in various forms using **C#** and **Selenium**. As a beginner, I have documented my learning process while writing this code.

---

## **Prerequisites**

To work with this project, ensure you meet the following requirements:
1. Basic programming experience (any programming language).
2. Visual Studio 2022 installed on your system.
3. Familiarity with HTML and CSS syntax.

---

## **Resources**

Here are some resources that helped me during this project:

1. Learn **C#**: [W3Schools](https://www.w3schools.com/cs/index.php).
2. Selenium automation using C#:
   - [GeeksforGeeks Documentation](https://www.geeksforgeeks.org/selenium-with-c-for-automated-browser-testing/).
   - [BrowserStack Guide](https://www.browserstack.com/guide/selenium-with-c-sharp-for-automated-test).
3. Handling **iframes** in Selenium: [NumPy Ninja Guide](https://www.numpyninja.com/post/handling-iframe-in-selenium#:~:text=Handling%20Nested%20IFrames%20in%20Selenium&text=We%20can%20access%20the%20content,any%20of%20the%20known%20methods).
4. **Shadow DOM** basics: [MDN Web Docs](https://developer.mozilla.org/en-US/docs/Web/API/Web_components/Using_shadow_DOM).
5. Automating Shadow DOM elements in Selenium:
   - [StackOverflow Guide](https://stackoverflow.com/questions/55761810/how-to-automate-shadow-dom-elements-using-selenium).
   - [Selenium and Shadow DOM](https://stackoverflow.com/questions/51346883/selenium-webdriver-with-shadow-dom).
6. Using **CSS Selectors** in Selenium: [BrowserStack Guide](https://www.browserstack.com/guide/css-selectors-in-selenium).
7. Selenium and C#: [Javatpoint Guide](https://www.javatpoint.com/selenium-csharp).

---

## **Tools Used**

This project uses the following tools and libraries:
1. **NUnit** for test case creation.
2. **Selenium WebDriver** for browser automation.
3. **Selenium Support** for additional helper methods.

To set up your Visual Studio environment and get started, refer to this [guide](https://www.browserstack.com/guide/selenium-with-c-sharp-for-automated-test).  
If you encounter errors like missing tools or SDK issues, check this [troubleshooting documentation](https://learn.microsoft.com/en-us/answers/questions/1184941/the-sdk-microsoft-net-sdk-specified-could-not-be-f).

---

## **Project Overview**

This project tests input fields inside forms across various challenging scenarios. These scenarios are designed to simulate how forms or elements might be structured in real-world applications:

### **Form Scenarios**
1. **Normal Form:** A simple form located on the webpage.
2. **Nested iframes:** 
   - One iframe (`iframe1`) contains another iframe (`iframe2`), which in turn contains:
     - A form.
     - Another iframe (`iframe3`) with another nested form.
3. **Iframe with an ID:** A uniquely identified iframe containing a form.
4. **Shadow DOMs:** A deeply nested structure with 5 levels of shadow DOMs, each containing a form.

### **Objective**
The goal is to test and validate input fields inside each form across these scenarios.

---

## **How to Use This Project**

1. Clone the repository.
2. Open the project in **Visual Studio 2022**.
3. Run the tests to validate input fields in different form setups.

---

## **Learning and Building**

This project reflects my journey of learning C# and Selenium. Along the way, I explored the following concepts:
- Navigating iframes.
- Handling Shadow DOMs.
- Writing reusable test code.
- Utilizing CSS selectors for locating elements.

---

Feel free to explore the provided resources and references to help you get started or dive deeper into Selenium automation!  

Special thanks to **ChatGPT** for helping me write this readable and comprehensive documentation!  

Happy Coding! 🎉
