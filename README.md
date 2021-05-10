# Project_9_CMPS358
CMPS 358 Programming Project #9


Project Description:


1. Work the tutorial as given in “11f_CreatingRazorDatabaseProject_world.pdf”.
 
2. When the tutorial is complete, create additional code that uses LINQ and / or extensions and forms in
“Index.cshtml.cs” and “Index.cshtml” to find and list


(a) all countries in a continent entered or chosen by the user. The countries are to be listed in
alphabetical order.


(b) the country, continent, region and country code of all countries that begin with the letter entered by
the user.


(c) information about a city. The user is to enter the name of city to be listed. Every instance of a city
with the entered name is to be displayed, including the city name, population, district, country and
country code. (For instance, there is a London in the United Kingdom and in Canada.)


Tips:

• In the C# code that retrieves countries by first letter and the list of city information, collect and return the
information in a List<string>.

• Use a Razor code block “@{ … }“ to receive a List<string> and a foreach to output the individual
strings.

• To place strings on a single line, use a combination of an explicit and implicit Razor expression.


For example:

@expression

<br>


• Be sure to check for a no result condition and return an object or value appropriate to the method. For
instance, an empty string or an empty List<T>.
  

General requirements:


• At the top of each file containing your C# code, insert the following comments:


// your-name

// your-ulid

// CMPS 358

// project #the-number-of-the-project


Submitting:


When the project is complete and runs correctly, clean the project, zip the project folder into a zip
archive, name the zip archive “p9_your-ulid.zip” and upload it in Moodle.
