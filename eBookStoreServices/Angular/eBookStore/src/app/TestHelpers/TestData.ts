import { Book } from '../Shared/Models/Book';
import { CartItem, CartItemDetails } from '../Shared/Models/Cart';

export const bookData: Book[] = [ 
    { 
       "ID":1,
       "Title":"Test 1",
       "Author":"Test 1",
       "Description":"Testing",
       "Publisher":"Test 1",
       "PublishedYear":2020,
       "Price":200.0
    },
    { 
       "ID":3,
       "Title":"Programming JavaScript Applications",
       "Author":"Eric Elliott",
       "Description":"Robust Web Architecture ",
       "Publisher":"O'Reilly Media",
       "PublishedYear":2020,
       "Price":1.0
    },
    { 
       "ID":4,
       "Title":"Speaking Test",
       "Author":"Axel Rauschmayer",
       "Description":"An In-Depth Guide for Programmers",
       "Publisher":"2020",
       "PublishedYear":2020,
       "Price":1.0
    },
    { 
       "ID":5,
       "Title":"Testing 1",
       "Author":"Testing",
       "Description":"Testing",
       "Publisher":"2020",
       "PublishedYear":2020,
       "Price":212.0
    },
    { 
       "ID":6,
       "Title":"Testing 1",
       "Author":"Testing",
       "Description":"Testing",
       "Publisher":"Testing",
       "PublishedYear":2020,
       "Price":212.0
    },
    { 
       "ID":7,
       "Title":"Git Pocket Guide",
       "Author":"Richard E. Silverman",
       "Description":"test",
       "Publisher":"O'Reilly Media",
       "PublishedYear":2013,
       "Price":200.0
    },
    { 
       "ID":8,
       "Title":"Git Pocket Guide",
       "Author":"Richard E. Silverman",
       "Description":"testing 123",
       "Publisher":"O'Reilly Media",
       "PublishedYear":2013,
       "Price":200.0
    },
    { 
       "ID":9,
       "Title":"Testing 1",
       "Author":"Testing",
       "Description":"Testing",
       "Publisher":"Testing",
       "PublishedYear":2020,
       "Price":212.0
    },
    { 
       "ID":10,
       "Title":"Testing 1",
       "Author":"Testing",
       "Description":"Testing",
       "Publisher":"Testing",
       "PublishedYear":2020,
       "Price":212.0
    },
    { 
       "ID":11,
       "Title":"Testing 1",
       "Author":"Testing",
       "Description":"Testing",
       "Publisher":"Testing",
       "PublishedYear":2020,
       "Price":212.0
    },
    { 
       "ID":12,
       "Title":"Git Pocket ",
       "Author":"Test",
       "Description":"test",
       "Publisher":"test",
       "PublishedYear":2020,
       "Price":200.0
    },
    { 
       "ID":13,
       "Title":"Testing 1",
       "Author":"Testing",
       "Description":"Testing",
       "Publisher":"Testing",
       "PublishedYear":2020,
       "Price":212.0
    },
    { 
       "ID":14,
       "Title":"Testing 1",
       "Author":"Testing",
       "Description":"Testing",
       "Publisher":"Testing",
       "PublishedYear":2020,
       "Price":212.0
    },
    { 
       "ID":15,
       "Title":"Test 1",
       "Author":"Test 1",
       "Description":"Testing",
       "Publisher":"Test 1",
       "PublishedYear":2020,
       "Price":200.0
    }
 ];

 export const cartData : CartItemDetails[] =[ 
    { 
       "Quantity":1,
       "AddedDate":"2019-12-23T22:42:12.18",
       "ID":9,
       "Title":"Testing 1",
       "Author":"Testing",
       "Description":"Testing",
       "Publisher":"Testing",
       "PublishedYear":2020,
       "Price":212.0
    },
    { 
       "Quantity":1,
       "AddedDate":"2019-12-23T22:42:19.833",
       "ID":5,
       "Title":"Testing 1",
       "Author":"Testing",
       "Description":"Testing",
       "Publisher":"2020",
       "PublishedYear":2020,
       "Price":212.0
    }
 ] ;

 export const orderDetails: any =[ 
    { 
       "bookDetailsForOrder":[ 
          { 
             "ID":3,
             "Title":"Programming JavaScript Applications",
             "Author":"Eric Elliott",
             "Description":"Robust Web Architecture ",
             "Publisher":"O'Reilly Media",
             "PublishedYear":2020,
             "Price":1.0
          }
       ],
       "ID":1,
       "UserID":"8ba72045-43b9-441b-868d-f7373bf02859",
       "PurchaseDate":"2019-12-21T15:04:26.523",
       "TotalPrice":1.0,
       "OrderStatus":1,
       "Order_Items":[ 
          { 
             "ID":1,
             "OrderNumber":1,
             "BookID":3,
             "Quantity":1
          }
       ]
    },
    { 
       "bookDetailsForOrder":[ 
          { 
             "ID":6,
             "Title":"Testing 1",
             "Author":"Testing",
             "Description":"Testing",
             "Publisher":"Testing",
             "PublishedYear":2020,
             "Price":212.0
          },
          { 
             "ID":3,
             "Title":"Programming JavaScript Applications",
             "Author":"Eric Elliott",
             "Description":"Robust Web Architecture ",
             "Publisher":"O'Reilly Media",
             "PublishedYear":2020,
             "Price":1.0
          },
          { 
             "ID":1,
             "Title":"Test 1",
             "Author":"Test 1",
             "Description":"Testing",
             "Publisher":"Test 1",
             "PublishedYear":2020,
             "Price":200.0
          },
          { 
             "ID":7,
             "Title":"Git Pocket Guide",
             "Author":"Richard E. Silverman",
             "Description":"test",
             "Publisher":"O'Reilly Media",
             "PublishedYear":2013,
             "Price":200.0
          },
          { 
             "ID":8,
             "Title":"Git Pocket Guide",
             "Author":"Richard E. Silverman",
             "Description":"testing 123",
             "Publisher":"O'Reilly Media",
             "PublishedYear":2013,
             "Price":200.0
          }
       ],
       "ID":2,
       "UserID":"8ba72045-43b9-441b-868d-f7373bf02859",
       "PurchaseDate":"2019-12-21T15:05:01.64",
       "TotalPrice":614.0,
       "OrderStatus":1,
       "Order_Items":[ 
          { 
             "ID":2,
             "OrderNumber":2,
             "BookID":6,
             "Quantity":1
          },
          { 
             "ID":3,
             "OrderNumber":2,
             "BookID":3,
             "Quantity":1
          },
          { 
             "ID":4,
             "OrderNumber":2,
             "BookID":1,
             "Quantity":1
          },
          { 
             "ID":5,
             "OrderNumber":2,
             "BookID":7,
             "Quantity":1
          },
          { 
             "ID":6,
             "OrderNumber":2,
             "BookID":8,
             "Quantity":1
          }
       ]
    },
    { 
       "bookDetailsForOrder":[ 
          { 
             "ID":1,
             "Title":"Test 1",
             "Author":"Test 1",
             "Description":"Testing",
             "Publisher":"Test 1",
             "PublishedYear":2020,
             "Price":200.0
          },
          { 
             "ID":3,
             "Title":"Programming JavaScript Applications",
             "Author":"Eric Elliott",
             "Description":"Robust Web Architecture ",
             "Publisher":"O'Reilly Media",
             "PublishedYear":2020,
             "Price":1.0
          },
          { 
             "ID":4,
             "Title":"Speaking Test",
             "Author":"Axel Rauschmayer",
             "Description":"An In-Depth Guide for Programmers",
             "Publisher":"2020",
             "PublishedYear":2020,
             "Price":1.0
          },
          { 
             "ID":6,
             "Title":"Testing 1",
             "Author":"Testing",
             "Description":"Testing",
             "Publisher":"Testing",
             "PublishedYear":2020,
             "Price":212.0
          }
       ],
       "ID":3,
       "UserID":"8ba72045-43b9-441b-868d-f7373bf02859",
       "PurchaseDate":"2019-12-21T18:00:25.857",
       "TotalPrice":215.0,
       "OrderStatus":1,
       "Order_Items":[ 
          { 
             "ID":7,
             "OrderNumber":3,
             "BookID":1,
             "Quantity":1
          },
          { 
             "ID":8,
             "OrderNumber":3,
             "BookID":3,
             "Quantity":1
          },
          { 
             "ID":9,
             "OrderNumber":3,
             "BookID":4,
             "Quantity":1
          },
          { 
             "ID":10,
             "OrderNumber":3,
             "BookID":6,
             "Quantity":1
          }
       ]
    },
    { 
       "bookDetailsForOrder":[ 
          { 
             "ID":3,
             "Title":"Programming JavaScript Applications",
             "Author":"Eric Elliott",
             "Description":"Robust Web Architecture ",
             "Publisher":"O'Reilly Media",
             "PublishedYear":2020,
             "Price":1.0
          }
       ],
       "ID":5,
       "UserID":"8ba72045-43b9-441b-868d-f7373bf02859",
       "PurchaseDate":"2019-12-22T13:44:55.363",
       "TotalPrice":1.0,
       "OrderStatus":1,
       "Order_Items":[ 
          { 
             "ID":15,
             "OrderNumber":5,
             "BookID":3,
             "Quantity":1
          }
       ]
    },
    { 
       "bookDetailsForOrder":[ 
          { 
             "ID":1,
             "Title":"Test 1",
             "Author":"Test 1",
             "Description":"Testing",
             "Publisher":"Test 1",
             "PublishedYear":2020,
             "Price":200.0
          }
       ],
       "ID":6,
       "UserID":"8ba72045-43b9-441b-868d-f7373bf02859",
       "PurchaseDate":"2019-12-24T00:45:10.323",
       "TotalPrice":400.0,
       "OrderStatus":1,
       "Order_Items":[ 
          { 
             "ID":16,
             "OrderNumber":6,
             "BookID":1,
             "Quantity":1
          }
       ]
    },
    { 
       "bookDetailsForOrder":[ 
          { 
             "ID":1,
             "Title":"Test 1",
             "Author":"Test 1",
             "Description":"Testing",
             "Publisher":"Test 1",
             "PublishedYear":2020,
             "Price":200.0
          }
       ],
       "ID":7,
       "UserID":"8ba72045-43b9-441b-868d-f7373bf02859",
       "PurchaseDate":"2019-12-24T09:52:36.273",
       "TotalPrice":400.0,
       "OrderStatus":1,
       "Order_Items":[ 
          { 
             "ID":18,
             "OrderNumber":7,
             "BookID":1,
             "Quantity":1
          }
       ]
    },
    { 
       "bookDetailsForOrder":[ 
          { 
             "ID":1,
             "Title":"Test 1",
             "Author":"Test 1",
             "Description":"Testing",
             "Publisher":"Test 1",
             "PublishedYear":2020,
             "Price":200.0
          },
          { 
             "ID":3,
             "Title":"Programming JavaScript Applications",
             "Author":"Eric Elliott",
             "Description":"Robust Web Architecture ",
             "Publisher":"O'Reilly Media",
             "PublishedYear":2020,
             "Price":1.0
          }
       ],
       "ID":8,
       "UserID":"8ba72045-43b9-441b-868d-f7373bf02859",
       "PurchaseDate":"2019-12-24T09:56:14.403",
       "TotalPrice":400.0,
       "OrderStatus":1,
       "Order_Items":[ 
          { 
             "ID":20,
             "OrderNumber":8,
             "BookID":1,
             "Quantity":1
          },
          { 
             "ID":21,
             "OrderNumber":8,
             "BookID":3,
             "Quantity":1
          }
       ]
    }
 ];
