import React,{Component} from 'react';
import {Header} from './Header';
import {BookCard} from './BookCard';
import {Footer} from './Footer';

export class DashBoard extends Component {
    state={
        books:[
        {
            bookid : 212323,
            bookName : "Baghban",
            authorName : "shreyash kaushal",
            price : 1235,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : ""
        },
        {
            bookid : 212323,
            bookName : "biography",
            authorName : "saad samim",
            price : 12356,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : ""

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : ""

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : ""

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : ""

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : ""

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : ""

        },
        {
            bookid : 212323,
            bookName : "JK rowling",
            authorName : "shivam",
            price : 45394,
            description : "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
            image : ""

        }
    ]
    }
    render()
    {
        return (
           <div className ='dashboard-div'>
               <Header/>
               <div className='card-header'>
                        <div className="BookCard-Header">Books</div>
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
