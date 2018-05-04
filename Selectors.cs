using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedForums_testing
{
    public class Selectors
    {

        //Login page
        public static string userName = "input[id='id_username']";
        public static string password = "input[id='id_password']";
        public static string loginButton = "input[value='Log in']";

        //Admin page
        public static string viewSite = "VIEW SITE";

        //Main page
        public static string addProduct = "Feature your Education Product";

        //Product Selection
        public static string conference = "a[href='products/add/conference']";
        public static string app = "a[href='products/add/app']";
        public static string book = "a[href='products/add/book']";
        public static string blog = "a[href='products/add/blog']";
        public static string course = "a[href='products/add/course']";
        public static string onlineResource = "a[href='products/add/web']";
        public static string podcast = "a[href='products/add/podcast']";

        //Add Product Details Page:
        public static string name = "input[id='id_name']";
        public static string productUrl = "input[id='id_product_url']";
        public static string minPrice = "id_price";
        public static string maxPrice = "id_price_max";
        public static string description = "id_description";
        public static string company = "id_company";
        public static string discountCode = "id_discount_code";
        public static string facebookLink = "id_fb_url";
        public static string twitterLink = "id_twitter_url";
        public static string twitterAccount = "id_twitter_handles";
        public static string occupationDropdown = "occupation-button";
        public static string specialityDropdown = "speciality-button";
        public static string otherDropdown = "other-button";
        public static string license = "select[name='license_type_select']";
        public static string submitButton = "button[name='submitFormButton']";

        //Conference Specific
        public static string conferenceLocation = "input[id='id_location_name']";
        public static string startDate = "id_start_date";
        public static string endDate = "id_end_date";
        public static string venueName = "id_location_venue_name";
        public static string locationAddress = "id_location_address";

        //App Specific
        public static string appAuthor = "p[class ='product-author']";
        public static string appleLink = "id_ios_url";
        public static string googleLink = "id_android_url";

        //Book Specific
        public static string bookAuthor = "id_author";
        public static string pageCount = "id_time_commitment";
        public static string ISBN = "id_isbn";

        //Blog Specific
        public static string blogAuthor = "id_author";

        //Online Resource Specific

        //Course Specific
        public static string courseLocation = "input[id='id_location_name']";
        public static string courseStart = "id_start_date";
        public static string courseEnd = "id_end_date";

        //Occupation Options
        public static string physician = "div[data- occupation-id = '16']";
        public static string physicianAssistant = "div[data- occupation-id = '17']";
        public static string nursePractitioner = "div[data- occupation-id = '18']";
        public static string resident = "div[data- occupation-id = '19']";
        public static string medStudent = "div[data- occupation-id = '20']";
        public static string other = "div[data- occupation-id = '21']";

        //Speciality Options
        public static string allergyImmunology = "div[data-speciality-id='22']";
        public static string anesthesiology = "div[data-speciality-id='23']";
        public static string cardiology = "div[data-speciality-id='24']";
        public static string childNeurology = "div[data- occupation-id = '25']";
        public static string colonRectal = "div[data- occupation-id = '26']";
        public static string dermatology = "div[data- occupation-id = '27']";
        public static string emergencyMedicine = "div[data-speciality-id='28']";
        public static string familyMedicine = "div[data-speciality-id='29']";
        public static string gastroenterology = "div[data-speciality-id='30']";
        public static string surgery = "div[data-occupation-id = '31']";
        public static string geriatrics = "div[data-occupation-id = '32']";

        //Other Options
        public static string familyFriendly = "div[data-other-id='6']";
        public static string adultsOnly = "div[data-other-id='7']";
        public static string USMLE = "div[data-other-id='8']";
        public static string USMLE1 = "div[data-other-id='9']";
        public static string USMLE2 = "div[data-other-id='10']";
        public static string USMLE3 = "div[data-other-id='11']";
        public static string QBank = "div[data-other-id='12']";
        public static string testPrep = "div[data-other-id='13']";
        public static string residentRotation = "div[data-other-id='14']";
        public static string rebel = "div[data-other-id='15']";

        //Results Page
        public static string productName = "p[class ='product-name']";
        public static string productDescription = "truncated-description";
        public static string productAuthor = "p[class ='product-author']";
        public static string productDate = "product-date-range";

    }
}
