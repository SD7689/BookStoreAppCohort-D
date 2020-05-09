import React,{Component} from 'react';
import {Header} from './Header';
import {BookCard} from './BookCard';
import {Footer} from './Footer';
import Demobook from '../Asserts/Demobook.jpg'
import nightBook from '../Asserts/nightBook.jpg'
import beauty from '../Asserts/beauty.jpg'
import winzar from '../Asserts/winzar.jpg'
import hypocrite from '../Asserts/hypocrite.jpg'
import journey from '../Asserts/journey.jpg'
import neighbouring from '../Asserts/neighbouring.jpg'
import west from '../Asserts/west.jpg'

export class DashBoard extends Component {
    state={
        books:[
        {
            bookid : 212323,
            bookName : "Baghban",
            authorName : "Amitabh Bachan",
            price : 1235,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image :  Demobook 
        },
        {
            bookid : 212323,
            bookName : "Jayant Biography",
            authorName : "Jay",
            price : 12356,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image :  nightBook 

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "Rowler",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : west

        },
        {
            bookid : 212323,
            bookName : "Harry Potter",
            authorName : "K Smith",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : winzar

        },
        {
            bookid : 212323,
            bookName : "Biography",
            authorName : "xyz",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : hypocrite

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : neighbouring

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : beauty

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : journey

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : Demobook

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : west

        },
        
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : winzar

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : hypocrite

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : west

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : Demobook

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : nightBook

        },
        
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : journey

        },
    ]
    }
    render()
    {
        return (
           <div className ='dashboard-div'>
               <Header/>
               <div className='card-header'>
                        <div className="BookCard-Header">Books</div>
                        <div className="book-count-div">(128 items)</div>
                        <div class="sort-by-div">
                    <select className="select-bar">
                        <option>Sort By</option>
                        <option>Price: high to low</option>
                        <option>Price: low to high</option>
                        <option>Newest arrivals</option>
                    </select>
            </div>
               </div>
               <BookCard books={this.state.books} />
               <Footer/>
           </div>
        );
    }
}
