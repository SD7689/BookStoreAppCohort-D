import React, { Component } from 'react';
import { Header } from './Header';
import { BookCard } from './BookCard';
import { Footer } from './Footer';
import axios from 'axios'
import { AddCartPage } from './AddCartPage'
//import { OrderPlaced } from './OrderPlaced'
import OrderPlaced from '../components/OrderPlaced'

export class DashBoard extends Component {
    state = {
        books: [],
        NumOfBooks: 0,
        cartCounter: 0,
        text: "Add To Bag",
        showWishlist: false,
        disableButton: false,
        showAddCartPage: false,
        showCartCounter: false,
        showCustomerDetails: false,
        clickedID : [] ,
        showOrderPlacedPage: false
    }

    addToCartPageHandler = async () => {
        let doesShowCartPage = this.state.showAddCartPage;
        await this.setState({
            showAddCartPage: !doesShowCartPage
        })
    }
    orderPlacedPageHandler = async () => {
        let doesShowOrderPlacedPage = this.state.showOrderPlacedPage;
        await this.setState({
            showOrderPlacedPage: !doesShowOrderPlacedPage
        })
    }
    customerDetailsShowHandler = async () => {
        let doesShowCustomerDetails = this.state.showCustomerDetails;
        await this.setState({
            showCustomerDetails: !doesShowCustomerDetails
        })
    }

    cartCountHandler = async (clickedID) => {
        let count = this.state.cartCounter;
        let doesShowWishlist = this.state.showWishlist;
        let doesDisableButton = this.state.disableButton
        let doesShowCartCounter = this.state.showCartCounter;
        let clickedidArray = this.state.clickedID;
        clickedidArray.push(clickedID);
        console.log(clickedID);
        await this.setState({
            cartCounter: count + 1,
            clickedID: [...clickedidArray],
            text: "Added To Bag",
            showWishlist: !doesShowWishlist,
            disableButton: !doesDisableButton,
            showCartCounter: !doesShowCartCounter
        })
        console.log("counter", this.state.cartCounter)
    }

    componentDidMount() {
        axios.get("https://localhost:5001/api/Book/GetAllBook")
            .then(response => {
                const books = response.data;
                this.setState({
                    books: books
                })
            })
        axios.get("https://localhost:5001/api/Book/NumOfBooks")
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
    /*onClickButton1 = async() => {
    await this.setState({
     text: "Added To Bag"
   });
 }*/
    render() {
        return (
            <div className='dashboard-div'>
                <Header 
                cartCount={this.state.cartCounter} 
                showAddCartPage={this.addToCartPageHandler} 
                showCartCounter={this.state.showCartCounter}
                />

                {
                    this.state.showAddCartPage ?
                        <>
                            <AddCartPage 
                            showCustomerDetails={this.customerDetailsShowHandler} 
                            showDetails={this.state.showCustomerDetails}        
        showOrderPlacedPage = {this.state.showOrderPlacedPage}
        orderPlacedPageHandler = {this.orderPlacedPageHandler}

                            />
                       </>
                        :
                        <>
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
                            <BookCard 
                            cartCounter={this.cartCountHandler} 
                            books={this.state.books} text={this.state.text} 
                            showWishlist={this.state.showWishlist} 
                            disableButton={this.state.disableButton}  
                            />
                        </>
                }
               
                <Footer />
            </div>
        );
    }
}
