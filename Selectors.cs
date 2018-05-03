using System;


namespace MedForums_testing
{
	public static class Selectors
	{
        //Login page
        var userName = driver.FindElement(By.CssSelector("input[id='id_username']"));
        var password = driver.FindElement(By.CssSelector("input[id='id_password']"));
        var loginButton = driver.FindElement(By.CssSelector("input[value='Log in']"));

    }
}
