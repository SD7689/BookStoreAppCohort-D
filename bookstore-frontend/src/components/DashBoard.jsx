import React, { Component } from 'react';
import { Header } from './Header';
import { BookCard } from './BookCard';
import { Footer } from './Footer';
import axios from 'axios'
import { AddCartPage } from './AddCartPage'
import { AddCartRequestMethod } from '../Services/CartServices'
import Pagination from './Pagination'
export class DashBoard extends Component {
    state = {
        books: [],
        NumOfBooks: 0,
        cartCounter: 0,
        showWishlist: false,
        disableButton: false,
        showAddCartPage: false,
        showCartCounter: false,
        showCustomerDetails: false,
        clickedId: [],
        showOrderPlacedPage: false,
        cart: [],
        currentPage: 1,
        postsPerPage: 12

    }

    paginate = (pageNumber) => {
        this.setState({
            currentPage: pageNumber
        })
        console.log("pagenumber after", this.state.currentPage);
    }

    addToCartPageHandler = async () => {
        let doesShowCartPage = this.state.showAddCartPage;
        await this.setState({
            showAddCartPage: !doesShowCartPage
        })
    }

    cartCountHandler = (clickedID, bookAvailable) => {
        let count = this.state.cartCounter;
        let doesShowWishlist = this.state.showWishlist;
        let doesDisableButton = this.state.disableButton;
        let clickedidArray = this.state.clickedId;
        clickedidArray.push(clickedID);
        console.log(" click id is", clickedID);
        let doesShowCartCounter = this.state.showCartCounter;
        this.setState({
            cartCounter: count + 1,

            clickedId: [...clickedidArray],
            showWishlist: !doesShowWishlist,
            disableButton: !doesDisableButton,
            showCartCounter: !doesShowCartCounter
        })
        var cart = {
            bookId: clickedID,
            numOfCopies: bookAvailable
        }
        const response = AddCartRequestMethod(cart);
        response.then(res => {
            console.log(res.data);
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

    orderPlacedPageHandler = async () => {
        let doesShowOrderPlacedPage = this.state.showOrderPlacedPage;
        await this.setState({
            showOrderPlacedPage: !doesShowOrderPlacedPage
        })
    }

    render() {
        const indexOfLastPost = this.state.currentPage * this.state.postsPerPage;
        const indexOfFirstPost = indexOfLastPost - this.state.postsPerPage;
        const currentPosts = this.state.books.slice(indexOfFirstPost, indexOfLastPost)
        return (
            <div className='dashboard-div'>
                <Header
                    cartCount={this.state.cartCounter}
                    showAddCartPage={this.addToCartPageHandler}
                    showCartCounter={this.state.showCartCounter}
                />
                {
                    this.state.showAddCartPage ?
                        <AddCartPage
                        />
                        :
                        <>
                            <div className='card-header'>
                                <div className="BookCard-Header">
                                    <h5>Books<span id='bookcountfont'>({this.state.NumOfBooks} items)</span></h5>
                                </div>
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
                                books={currentPosts}
                                cartCounter={this.cartCountHandler}
                                //  books={this.state.books} text={this.state.text} 
                                showWishlist={this.state.showWishlist}
                                disableButton={this.state.disableButton}
                                clickedId={this.state.clickedId}
                            />
                            <Pagination postsPerPage={this.state.postsPerPage}
                                totalPosts={this.state.books.length}
                                paginateNumber={this.paginate} />
                        </>
                }
                <Footer />
            </div>
        );
    }
}