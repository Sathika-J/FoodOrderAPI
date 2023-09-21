using FoodOrderApi.Model.Domain;
using FoodOrderApi.Model.DTO;

namespace FoodOrderApi.TestApi.Mockdata
{
    public class RestaurantMockData
    {
        public static List<Restaurant> GetAllRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                    new Restaurant()
                {
                    RestaurantID = Guid.Parse("BAAD586A-ACCF-4433-98F0-2F861E683354"),
                    RestaurantName = "Kove",
                    RestaurantType = "Fine Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Ramanathpuram"
                },
                    new Restaurant()
                {
                    RestaurantID = Guid.Parse("F40029F8-9C8F-4ABF-8DB5-FFA00A13D1CD"),
                    RestaurantName = "Anadha Bhavan",
                    RestaurantType = "Fine Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Peelamedu"
                },new Restaurant()
                {
                    RestaurantID = Guid.Parse("D487C6EC-2A8B-44A1-BA0E-F4FF24A9E7CE"),
                    RestaurantName = "Adyar Anadha Bhavan",
                    RestaurantType = "Fine Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Perambur"
                },new Restaurant()
                {
                    RestaurantID = Guid.Parse("A082A822-C7F0-4EA0-837D-957A5B154908"),
                    RestaurantName = "Arya Bhavan",
                    RestaurantType = "Fine Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Kalpakam"
                },
                    new Restaurant()
                {
                    RestaurantID = Guid.Parse("6069CED7-F6CF-4D8D-999E-78566375AD55"),
                    RestaurantName = "Mario Hotel",
                    RestaurantType = "Fine Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Mars"
                },new Restaurant()
                {
                    RestaurantID = Guid.Parse("0C2B4710-050E-4794-8031-E5FC19EF13B4"),
                    RestaurantName = "KB Bhavan",
                    RestaurantType = "Fine Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Jupiter"
                },new Restaurant()
                {
                    RestaurantID = Guid.Parse("EE05C50F-D96E-4FD8-B84E-708C772DC026"),
                    RestaurantName = "SMS Hotel",
                    RestaurantType = "Fine Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Pluto"
                },
                new Restaurant()
                {
                    RestaurantID =  Guid.Parse("7E83A461-5A28-4B11-83A5-31458449B7AC"),
                    RestaurantName = "Annapoorna",
                    RestaurantType = "Casual Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "RS Puram"
                },
                new Restaurant()
                {
                    RestaurantID =  Guid.Parse("7A03CA50-719F-48E7-AE0E-E4E299F3112B"),
                    RestaurantName = "Chocolate Room",
                    RestaurantType = "Desserts and Beerages",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Race Course Road"
                },
                new Restaurant()
                {
                    RestaurantID =  Guid.Parse("2818B184-94BE-4A91-A3B8-A510B00BD6F5"),
                    RestaurantName = "Orbis",
                    RestaurantType = "Multi Cuisine",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Avinashi Road"
                }
            };
            return restaurants;
        }

        public static List<Restaurant> GetFilteredRestaurants(string stringToBeFiltered)
        {
            return GetAllRestaurants().Where(x => x.RestaurantName.ToLower().Contains(stringToBeFiltered.ToLower())).ToList();
        }

        public static List<Menu> GetAllMenus()
        {
            var menu = new List<Menu>()
            {
                new Menu() {RestaurantID = Guid.Parse("BAAD586A-ACCF-4433-98F0-2F861E683354"), ProductID = Guid.Parse("E0194510-6AD1-4AC2-BF31-E572CAA09BA1"), ProductName = "Thai Broccoli Salad", ProductPrice = 205, ProductOffer = 10.00 },
                new Menu() {RestaurantID = Guid.Parse("BAAD586A-ACCF-4433-98F0-2F861E683354"), ProductID = Guid.Parse("983FC832-5371-4BDC-AF27-BD14F5998F44"), ProductName = "Curd Rice Aracini", ProductPrice = 200, ProductOffer = 20.00 },
                new Menu() {RestaurantID = Guid.Parse("BAAD586A-ACCF-4433-98F0-2F861E683354"), ProductID = Guid.Parse("AE527A12-BE03-4AC1-8206-7345A1A90BF6"), ProductName = "Chettinad Cutlet", ProductPrice = 255 , ProductOffer = 30.00},

                new Menu() {RestaurantID = Guid.Parse("F40029F8-9C8F-4ABF-8DB5-FFA00A13D1CD"), ProductID = Guid.Parse("26986DA6-4610-472E-B14A-30A713BDD30E"), ProductName = "Thai Broccoli Salad", ProductPrice = 205, ProductOffer = 10.00 },
                new Menu() {RestaurantID = Guid.Parse("F40029F8-9C8F-4ABF-8DB5-FFA00A13D1CD"), ProductID = Guid.Parse("F2612C12-B189-4D23-9532-E7C07A1EEBE3"), ProductName = "Curd Rice Aracini", ProductPrice = 275, ProductOffer = 20.00 },
                new Menu() {RestaurantID = Guid.Parse("F40029F8-9C8F-4ABF-8DB5-FFA00A13D1CD"), ProductID = Guid.Parse("D636DB98-A948-45AB-956B-9078A9252A42"), ProductName = "Chettinad Cutlet", ProductPrice = 255 , ProductOffer = 30.00},

                new Menu() {RestaurantID = Guid.Parse("D487C6EC-2A8B-44A1-BA0E-F4FF24A9E7CE"), ProductID = Guid.Parse("B6B56F12-0AC4-401C-82C6-9A5103870ED8"), ProductName = "Thai Broccoli Salad", ProductPrice = 200, ProductOffer = 10.00 },
                new Menu() {RestaurantID = Guid.Parse("D487C6EC-2A8B-44A1-BA0E-F4FF24A9E7CE"), ProductID = Guid.Parse("F613A27F-93C2-4028-9DEB-DDC4B8B45E3A"), ProductName = "Curd Rice Aracini", ProductPrice = 265, ProductOffer = 20.00 },
                new Menu() {RestaurantID = Guid.Parse("D487C6EC-2A8B-44A1-BA0E-F4FF24A9E7CE"), ProductID = Guid.Parse("289F9767-E25F-407D-AE50-72C3DEBE8CED"), ProductName = "Chettinad Cutlet", ProductPrice = 255 , ProductOffer = 30.00},

                new Menu() {RestaurantID = Guid.Parse("A082A822-C7F0-4EA0-837D-957A5B154908"), ProductID = Guid.Parse("0C976706-286A-4F66-A65B-12461D8847FB"), ProductName = "Thai Broccoli Salad", ProductPrice = 200, ProductOffer = 10.00 },
                new Menu() {RestaurantID = Guid.Parse("A082A822-C7F0-4EA0-837D-957A5B154908"), ProductID = Guid.Parse("999C9F43-5153-4E08-B471-1015BF08498E"), ProductName = "Curd Rice Aracini", ProductPrice = 205, ProductOffer = 20.00 },
                new Menu() {RestaurantID = Guid.Parse("A082A822-C7F0-4EA0-837D-957A5B154908"), ProductID = Guid.Parse("768B93DD-E9D4-4A64-941C-CF4A902B75A6"), ProductName = "Chettinad Cutlet", ProductPrice = 255 , ProductOffer = 30.00},

                new Menu() {RestaurantID = Guid.Parse("EE05C50F-D96E-4FD8-B84E-708C772DC026"), ProductID = Guid.Parse("2318C8A7-F867-415D-8427-DF4BBE527796"), ProductName = "Thai Broccoli Salad", ProductPrice = 200, ProductOffer = 10.00 },
                new Menu() {RestaurantID = Guid.Parse("EE05C50F-D96E-4FD8-B84E-708C772DC026"), ProductID = Guid.Parse("0BD3DEBF-0EC8-4CB4-9497-E76DA79EB9C8"), ProductName = "Curd Rice Aracini", ProductPrice = 205, ProductOffer = 20.00 },
                new Menu() {RestaurantID = Guid.Parse("EE05C50F-D96E-4FD8-B84E-708C772DC026"), ProductID = Guid.Parse("F1B97DB8-9B54-4616-8D49-B36E4CD08F5F"), ProductName = "Chettinad Cutlet", ProductPrice = 255, ProductOffer = 30.00 },

                new Menu() {RestaurantID = Guid.Parse("6069CED7-F6CF-4D8D-999E-78566375AD55"), ProductID = Guid.Parse("EA6460DF-D676-426C-8699-AE19230D743E"), ProductName = "Thai Broccoli Salad", ProductPrice = 200, ProductOffer = 10.00 },
                new Menu() {RestaurantID = Guid.Parse("6069CED7-F6CF-4D8D-999E-78566375AD55"), ProductID = Guid.Parse("6C9BA650-6204-4BA0-9602-4413932E36B1"), ProductName = "Curd Rice Aracini", ProductPrice = 205, ProductOffer = 20.00 },
                new Menu() {RestaurantID = Guid.Parse("6069CED7-F6CF-4D8D-999E-78566375AD55"), ProductID = Guid.Parse("019EC633-F286-4955-B473-D510DAF80960"), ProductName = "Chettinad Cutlet", ProductPrice = 255 , ProductOffer = 30.00},

                new Menu() {RestaurantID = Guid.Parse("0C2B4710-050E-4794-8031-E5FC19EF13B4"), ProductID = Guid.Parse("CFA81F1B-9DB5-43A4-962D-506E68615495"), ProductName = "Thai Broccoli Salad", ProductPrice = 200 , ProductOffer = 10.00},
                new Menu() {RestaurantID = Guid.Parse("0C2B4710-050E-4794-8031-E5FC19EF13B4"), ProductID = Guid.Parse("8DE20733-568B-430D-B642-A3A5254B6418"), ProductName = "Curd Rice Aracini", ProductPrice = 205 , ProductOffer = 20.00},
                new Menu() {RestaurantID = Guid.Parse("0C2B4710-050E-4794-8031-E5FC19EF13B4"), ProductID = Guid.Parse("6FA050AD-D0C1-41F0-A131-610C3E78E03D"), ProductName = "Chettinad Cutlet", ProductPrice = 255 , ProductOffer = 30.00},

                new Menu() {RestaurantID = Guid.Parse("7E83A461-5A28-4B11-83A5-31458449B7AC"), ProductID = Guid.Parse("BE5A857B-1336-4D13-A1D8-B0C9683689CA"), ProductName = "Idly(2)", ProductPrice = 33 , ProductOffer = 10.00},
                new Menu() {RestaurantID = Guid.Parse("7E83A461-5A28-4B11-83A5-31458449B7AC"), ProductID = Guid.Parse("780717AD-8473-4C23-B9B0-A256FD80F13F"), ProductName = "Pongal", ProductPrice = 48 , ProductOffer = 20.00},
                new Menu() {RestaurantID = Guid.Parse("7E83A461-5A28-4B11-83A5-31458449B7AC"), ProductID = Guid.Parse("E1764DA4-941D-463A-8531-43B701306780"), ProductName = "Roast", ProductPrice = 75 , ProductOffer = 30.00},

                new Menu() {RestaurantID = Guid.Parse("7A03CA50-719F-48E7-AE0E-E4E299F3112B"), ProductID = Guid.Parse("1FF36C1A-3E10-4651-88E4-7FC4736BF4D8"), ProductName = "Chocolate Sizzler", ProductPrice = 299 , ProductOffer = 10.00},
                new Menu() {RestaurantID = Guid.Parse("7A03CA50-719F-48E7-AE0E-E4E299F3112B"), ProductID = Guid.Parse("316DC710-146C-430B-9B0F-E9AA51B1E8E9"), ProductName = "Choco Brownie Bomb", ProductPrice = 249 , ProductOffer = 20.00},
                new Menu() {RestaurantID = Guid.Parse("7A03CA50-719F-48E7-AE0E-E4E299F3112B"), ProductID = Guid.Parse("3A011230-DB41-4407-9218-347F51391818"), ProductName = "Chocolate Cookies", ProductPrice = 199 , ProductOffer = 30.00},

                new Menu() {RestaurantID = Guid.Parse("2818B184-94BE-4A91-A3B8-A510B00BD6F5"), ProductID = Guid.Parse("C8E03D8C-3438-4583-B12E-1BA54C3670D6"), ProductName = "Vegetable Club Sandwich", ProductPrice = 150 , ProductOffer = 10.00},
                new Menu() {RestaurantID = Guid.Parse("2818B184-94BE-4A91-A3B8-A510B00BD6F5"), ProductID = Guid.Parse("A91BE131-8704-45AE-9BA7-60E70C58ABB4"), ProductName = "Veg Combo Meal", ProductPrice = 439 , ProductOffer = 20.00},
                new Menu() {RestaurantID = Guid.Parse("2818B184-94BE-4A91-A3B8-A510B00BD6F5"), ProductID = Guid.Parse("5849B06F-9731-4E31-A908-6E7E9DAFDD5A"), ProductName = "Orbis Signature Rice", ProductPrice = 250 , ProductOffer = 30.00}
            };
            return menu;
        }

        public static List<RestaurantWithMenu> GetRestaurantsWithMenu()
        {
            var restaurantswithmenu = new List<RestaurantWithMenu>()
            {
                  new RestaurantWithMenu()
                {
                    RestaurantID = Guid.Parse("BAAD586A-ACCF-4433-98F0-2F861E683354"),
                    RestaurantName = "Kove",
                    RestaurantType = "Fine Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Ramanathpuram",

                    Menus = new List<string> { "Thai Broccoli Salad", "Curd Rice Aracini", "Chettinad Cutlet" }
                },
                    new RestaurantWithMenu()
                {
                    RestaurantID = Guid.Parse("F40029F8-9C8F-4ABF-8DB5-FFA00A13D1CD"),
                    RestaurantName = "Anadha Bhavan",
                    RestaurantType = "Fine Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Peelamedu",
                    Menus = new List<string> { "Thai Broccoli Salad", "Curd Rice Aracini", "Chettinad Cutlet" }
                },new RestaurantWithMenu()
                {
                    RestaurantID = Guid.Parse("D487C6EC-2A8B-44A1-BA0E-F4FF24A9E7CE"),
                    RestaurantName = "Adyar Anadha Bhavan",
                    RestaurantType = "Fine Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Perambur",
                    Menus = new List<string> { "Thai Broccoli Salad", "Curd Rice Aracini", "Chettinad Cutlet" }
                },new RestaurantWithMenu()
                {
                    RestaurantID = Guid.Parse("A082A822-C7F0-4EA0-837D-957A5B154908"),
                    RestaurantName = "Arya Bhavan",
                    RestaurantType = "Fine Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Kalpakam",
                    Menus = new List<string> { "Thai Broccoli Salad", "Curd Rice Aracini", "Chettinad Cutlet" }
                },
                    new RestaurantWithMenu()
                {
                    RestaurantID = Guid.Parse("6069CED7-F6CF-4D8D-999E-78566375AD55"),
                    RestaurantName = "Mario Hotel",
                    RestaurantType = "Fine Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Mars",
                    Menus = new List<string> { "Thai Broccoli Salad", "Curd Rice Aracini", "Chettinad Cutlet" }
                },new RestaurantWithMenu()
                {
                    RestaurantID = Guid.Parse("0C2B4710-050E-4794-8031-E5FC19EF13B4"),
                    RestaurantName = "KB Bhavan",
                    RestaurantType = "Fine Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Jupiter",
                    Menus = new List<string> { "Thai Broccoli Salad", "Curd Rice Aracini", "Chettinad Cutlet" }
                },new RestaurantWithMenu()
                {
                    RestaurantID = Guid.Parse("EE05C50F-D96E-4FD8-B84E-708C772DC026"),
                    RestaurantName = "SMS Hotel",
                    RestaurantType = "Fine Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Pluto",
                    Menus = new List<string> { "Thai Broccoli Salad", "Curd Rice Aracini", "Chettinad Cutlet" }
                },
                new RestaurantWithMenu()
                {
                    RestaurantID =  Guid.Parse("7E83A461-5A28-4B11-83A5-31458449B7AC"),
                    RestaurantName = "Annapoorna",
                    RestaurantType = "Casual Dining",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "RS Puram",
                    Menus = new List<string> { "Idly(2)", "Pongal", "Roast" }
                },

                new RestaurantWithMenu()
                {
                    RestaurantID = Guid.Parse("7A03CA50-719F-48E7-AE0E-E4E299F3112B"),
                    RestaurantName = "Chocolate Room",
                    RestaurantType = "Desserts and Beerages",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Race Course Road",
                    Menus = new List<string> { "Chocolate Sizzler", "Choco Brownie Bomb", "Chocolate Cookies" }
                },

                new RestaurantWithMenu()
                {
                    RestaurantID = Guid.Parse("2818B184-94BE-4A91-A3B8-A510B00BD6F5"),
                    RestaurantName = "Orbis",
                    RestaurantType = "Multi Cuisine",
                    RestaurantPhoneNumber = 1234567890,
                    RestaurantLocation = "Avinashi Road",
                    Menus = new List<string> { "Vegetable Club Sandwich", "Veg Combo Meal", "Orbis Signature Rice" }
                }
            };
            return restaurantswithmenu;
        }

        public static (IEnumerable<Restaurant>, PaginationMetadata) GetRestaurantPaged(int pageNumber, int pageSize)
        {
            var productsCount = GetAllRestaurants().Count;
            var paginationMetadata = new PaginationMetadata(productsCount, pageSize, pageNumber);

            var paginatedProducts = GetAllRestaurants()
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList();
            return (paginatedProducts, paginationMetadata);
        }

        public static RestaurantsandMenus GetSearchRestaurantAndMenu(string stringToBeSearched)
        {
            var restaurants = GetAllRestaurants().AsQueryable();
            var menus = GetAllMenus().AsQueryable();
            restaurants = restaurants.Where(x => x.RestaurantName.ToLower().Contains(stringToBeSearched.ToLower()));
            menus = menus.Where(x => x.ProductName.ToLower().Contains(stringToBeSearched.ToLower()));

            RestaurantsandMenus restaurantsandMenus = new RestaurantsandMenus();
            restaurantsandMenus.menu = menus.ToList();
            restaurantsandMenus.restaurant = restaurants.ToList();
            return restaurantsandMenus;
        }
    }
}