# String Extension Methods
This contains Extension Methods that mostly deal with strings. You can check the examples below for more details. 
Followings are the Methods available for public use. 

- [IsDateTime()](#isdateTime)
- [IsInteger()](#isinteger)
- [IsDecimal()](#isdecimal)
- [IsNumeric()](#isnumeric)
- [IsGuid()](#isguid)
- [IsAlpha()](#isalpha)
- [IsAlphaNumeric()](#isalphanumeric)
- [IsEmailAddress()](#isemailaddress)
- [IsIPv4()](#isipv4)
- [IsMatch()](#ismatch)
- [ToCSVString()](#tocsvstring)
- [SplitTo()](#splitto)
- [ToBoolean()](#toboolean)
- [ToEnum()](#toenum)
- [GetNullIfEmptyString()](#getnullifemptystring)
- [FirstCharacter()](#firstcharacter)
- [LastCharacter()](#lastcharacter)
- [EndsWithIgnoreCase()](#endswithignorecase)
- [StartsWithIgnoreCase()](#startswithignorecase)

## Api Reference Details
* ### IsDateTime()
Checks if date string with dateFormat is parsable to ```System.DateTime``` format. True if is valid ```System.DateTime``` else returns false.
```csharp
/// data : datetime string
/// dateFormat : date format "dd/MM/yyyy" by default
public static bool IsDateTime(this string data, string dateFormat = "dd/MM/yyyy");
```
#### Example
```csharp
    var isDate = "09/10/2019".IsDateTime(); //Returns true.
    isDate = "11/28/2019".IsDateTime("MM/dd/yyyy"); // Returns true
    isDate = "11/28/2019".IsDateTime("dd/MM/yyyy"); // Returns false
```
* ### IsInteger()
Checks if a string is a valid int32 value. Returns true if the string is a valid Integer, else returns false.
```csharp
/// val : string value
public static bool IsInteger(this string val);
```
#### Example
```csharp
    var isNumber = "112".IsInteger(); //Returns true.
    isNumber = "-23".IsInteger(); // Returns true
    isNumber = "".IsInteger(); // Returns false
```
* ### IsDecimal()
Checks if a string is a valid decimal value. Returns true if the string is a valid decimal, else returns false.
```csharp
/// val : string value
public static bool IsDecimal(this string val);
```
#### Example
```csharp
    var isDecimal = "-112.0".IsDecimal(); //Returns true.
    isDecimal = "112".IsDecimal(); // Returns true
    isDecimal = "".IsDecimal(); // Returns false
```
* ### IsNumeric()
Checks if a string is a valid floating value. Returns true if the string is a valid floating, else returns false.
```csharp
/// val : string value
public static bool IsNumeric(this string val);
```
#### Example
```csharp
    var isNumeric = "-112.0".IsNumeric(); //Returns true.
    isNumeric = "112".IsNumeric(); // Returns true
    isNumeric = "".IsNumeric(); // Returns false
```
* ### IsGuid()
Checks if a string is a valid Guid value. Returns true if the string is a valid Guid, else returns false.
```csharp
/// val : string value
public static bool IsGuid(this string val);
```
#### Example
```csharp
    var isGuid = "ABCDER".IsGuid(); //Returns False.
    isGuid = "7FB05CF8-1D45-4935-81C0-A4DD22264C34".IsGuid(); // Returns true
    isGuid = "A005041CCCFF4D349AA0FF48F384A0D3".IsGuid(); // Returns true
```
* ### IsAlpha()
Checks if the String contains only Unicode letters. ```null``` will return false. An empty String ("") will return false.
```csharp
/// val : string value
public static bool IsAlpha(this string val);
```
#### Example
```csharp
    var isAlpha = "Abc Das".IsAlpha(); //Returns true.
    isAlpha = "Abc90Das".IsAlpha(); // Returns false
    isAlpha = "Abc$#3Das".IsAlpha(); // Returns false
```
* ### IsAlphaNumeric()
Checks if the String contains only Unicode letters, digits. ```null``` will return false. An empty String ("") will return false.
```csharp
/// val : string value
public static bool IsAlphaNumeric(this string val);
```
#### Example
```csharp
    var isAlphaNumeric = "Abc Das".IsAlphaNumeric(); //Returns true.
    isAlphaNumeric = "1234".IsAlphaNumeric(); //Returns true.
    isAlphaNumeric = "Abc90Das".IsAlphaNumeric(); // Returns true
    isAlphaNumeric = "Abc90DasA#$".IsAlphaNumeric(); // Returns false
```
* ### IsEmailAddress()
Validates email address. Returns true, if a given string is a valid email address. Else returns false.
```csharp
/// val : string value
public static bool IsEmailAddress(this string val);
```
#### Example
```csharp
    var isEmail = "abc@gmail.com".IsEmailAddress(); //Returns true.
    isEmail = "1234".IsEmailAddress(); //Returns false.
    isEmail = "23@gmail.com".IsEmailAddress(); // Returns false
    isEmail = "23+12@gmail.co.in.com".IsEmailAddress(); // Returns false
```
* ### IsIPv4()
Validates if a string is valid IPv4 Returns true, if a given string is a valid IP. Else returns false.
```csharp
/// val : string value
public static bool IsIPv4(this string val);
```
#### Example
```csharp
    var isIpV4 = "1.1.1.1".IsIPv4(); //Returns true.
    isIpV4 = ".1.1".IsIPv4(); //Returns false.
    isIpV4 = "23@gmail.com".IsIPv4(); // Returns false
    isIpV4 = "192.168.1.1".IsIPv4(); // Returns true
```
* ### IsMatch()
Determines whether the specified string matches a regular expression or not. Returns true if the regex matches, else returns false.
```csharp
/// val : string value
/// regEx : The reg ex.
public static bool IsMatch(this string content, string regEx);
```
#### Example
```csharp
    var isRegexMatch = "ssswagatss@gmail.com".IsMatch("^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"); //Returns true.
    isRegexMatch = "ssswagatss+09@gmail.com".IsMatch("^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"); //Returns false.
```
* ### IsUrl()
Determines whether this string is URL. Returns true if URL, else returns false.
```csharp
/// val : string value
public static bool IsUrl(this string val);
```
#### Example
```csharp
    var isUrl = "http://google.com".IsUrl(); //Returns true.
    isUrl = "http://go ogle.com".IsUrl(); //Returns false.
    isUrl = "http://google.com/abc-ght?url=bar".IsUrl(); //Returns true.
```
* ### ToCSVString()
Converts an object to CSV String separated by a Separator.
```csharp
/// val : string value
/// separator : string separator, be default it separates with comma.
public static string ToCSVString(this object obj, string separator = ",");
```
#### Example
```csharp
    var user = new TestUser { Id = 1, Name = "Extension Methods", Age = 18 };
    var csv =user.ToCSVString(); //Returns "1,Extension Methods,18"
    csv =user.ToCSVString("|"); //Returns "1|Extension Methods|18"
```
* ### SplitTo()
Returns an enumerable collection of the specified type containing the substrings in this instance that are delimited by elements of a specified Char array
```csharp
/// val : string value
/// separator : An array of Unicode characters that delimit the substrings in this instance, an empty array containing no delimiters, or null
public static IEnumerable<T> SplitTo<T>(this string val, params char[] separator) where T : IConvertible ;
```
#### Example
```csharp
    var bar = "23,34,56,-2,33,100";
    var foo = bar.SplitTo<int>(',').ToArray();  //Returns new int[] { 23, 34, 56, -2, 33, 100 };
```
There is one more overloaded method of `Split()` that Returns an enumerable collection of the specified type containing the substrings in this instance that are delimited by elements of a specified Char array, but this time it does so taking the `StringSplitOptions` into consideration.
```csharp
/// val : string value
/// options : Represents StringSplitOptions like 'RemoveEmptyEntries' or 'None'
/// separator : An array of Unicode characters that delimit the substrings in this instance, an empty array containing no delimiters, or null
public static IEnumerable<T> SplitTo<T>(this string val, StringSplitOptions options, params char[] separator) where T : IConvertible;
```
#### Example
```csharp
    var bar = "23,34,,56,,-2,33,100";
    var foo = bar.SplitTo<int>(StringSplitOptions.RemoveEmptyEntries, ',').ToArray(); //Returns new int[] { 23, 34, 56, -2, 33, 100 };
```
* ### ToBoolean()
Converts string to its boolean equivalent. This checks ignoring cases and trimming the string.
```csharp
/// val : string value
public static bool ToBoolean(this string val);
```
#### Example
```csharp
    "false".ToBoolean(); //Returns false
    "f".ToBoolean(); //Returns false
    "n".ToBoolean(); //Returns false
    "no".ToBoolean(); //Returns false
    "False".ToBoolean(); //Returns false
    "True".ToBoolean(); //Returns true
    "True".ToBoolean(); //Returns true
    "Yes".ToBoolean(); //Returns true
    "y".ToBoolean(); //Returns true
```
* ### ToEnum()
Converts string to its Enum type. Checks of string is a member of type `T` enum before converting. If fails returns `default enum`
```csharp
/// val : string value
public static T ToEnum<T>(this string val, T defaultValue = default(T), bool ignoreCase = false) where T : struct;
```
#### Example
```csharp
    public enum TestEnums
    {
        Admin = 1,
        PublicUser = 2,
        Supervisor = 3
    }
    
    "1".ToEnum<TestEnums>(); //Returns TestEnums.Admin
    "2".ToEnum<TestEnums>(); //Returns TestEnums.PublicUser
```
* ### GetNullIfEmptyString()
Checks if a string is Null or EmptyString (`string.Empty`), retuns NULL if the string is NULL or Empty and returns the same string if Not.
```csharp
/// val : string value
public static string GetNullIfEmptyString(this string val);
```
#### Example
```csharp
    var bar = " Swagat ".GetNullIfEmptyString(); //Returns Swagat
    bar = "".GetNullIfEmptyString(); //Returns null
```
* ### FirstCharacter()
 Gets first character in string
```csharp
/// val : string value
public static string FirstCharacter(this string val);
```
#### Example
```csharp
    var bar = "Royal College".FirstCharacter(); //Returns R
```
* ### LastCharacter()
 Gets Last character in string
```csharp
/// val : string value
public static string LastCharacter(this string val);
```
#### Example
```csharp
    var bar = "Royal College".LastCharacter(); //Returns e
```
* ### EndsWithIgnoreCase()
 Checks a String ends with another sub-string ignoring the case. If it does, returns true, else returns false.
```csharp
/// val : string value
public static bool EndsWithIgnoreCase(this string val, string suffix);
```
#### Example
```csharp
    var bar = "Royal College".EndsWithIgnoreCase("Ege"); //Returns true
```
* ### StartsWithIgnoreCase()
 Checks a String Starts with another sub-string ignoring the case. If it does, returns true, else returns false.
```csharp
/// val : string value
public static bool StartsWithIgnoreCase(this string val, string suffix);
```
#### Example
```csharp
    var bar = "Royal College".StartsWithIgnoreCase("royal"); //Returns true
```