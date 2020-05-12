import React,{Component} from 'react';
import {Header} from './Header';
import {BookCard} from './BookCard';
import {Footer} from './Footer';
import axios from 'axios'

export class DashBoard extends Component {
    state={
        books:[],
        NumOfBooks: 0,
        cartCounter:0
    }

    cartCountHandler = async () => {
        const count = this.state.cartCounter + 1;
        await this.setState({
            cartCounter: count
        })
        console.log("counter", this.state.cartCounter)
    }

    componentDidMount() {
        axios.get("https://localhost:44394/api/Book/GetAllBook")
            .then(response => {
                const books = response.data;
                this.setState({
                    books: books
                })
            })
            axios.get("https://localhost:44394/api/Book/NumOfBooks")
            .then(response => {
                const NumOfBooks = response.data;
                this.setState({
                    NumOfBooks: NumOfBooks
                })
            })
    }
    /*componentDidMount() {
        axios.get("https://localhost:44394/api/Book/NumOfBooks")
            .then(response => {
                const NumOfBooks = response.data;
                this.setState({
                    NumOfBooks: NumOfBooks
                })
            })
    }*/
    render()
    {
        return (
           <div className ='dashboard-div'>
               <Header cartCounter={this.state.cartCounter}/>
               <div className='card-header'>
                        <div className="BookCard-Header">Books</div>
                        <div className="book-count-div">({this.state.NumOfBooks} items)</div>
                        <div class="sort-by-div">
                    <select className="select-bar">
                        <option>Sort By</option>
                        <option>Price: high to low</option>
                        <option>Price: low to high</option>
                        <option>Newest arrivals</option>
                    </select>
            </div>
               </div>
               <BookCard cartCounter={this.cartCountHandler} books={this.state.books} />
               <Footer/>
           </div>
        );
    }
}
