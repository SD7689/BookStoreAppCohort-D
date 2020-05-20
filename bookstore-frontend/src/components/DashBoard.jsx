import React, { Component } from 'react';
import { Header } from './Header';
import { BookCard } from './BookCard';
import { Footer } from './Footer';
import axios from 'axios'
import { AddCartPage } from './AddCartPage'
//import { OrderPlaced } from './OrderPlaced'
import OrderPlaced from '../components/OrderPlaced'
import { getCartAddedCountRequestMethod,AddCartRequestMethod } from '../Services/CartServices'
import {getAllBooksRequestMethod, getBookCountRequestMethod} from '../Services/BookServices'
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
         cart:[],
         currentPage: 1,
        postsPerPage: 12,
        isSearching: false,
        filterArray: [],
        filterArrayCount: 0
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
    
    sortingHandler=(event)=>{
        const selection = event.target.value;
        let books = this.state.books;
        if (selection === "Price: low to high")
        {
            function compare(a, b){
            let comparison = 0
            if(a.bookPrice<b.bookPrice){
                comparison=-1
            }
                return comparison
            }
            this.setState({
                books: books.sort(compare)
            })
        }
        else{
            function compare(a, b){
                let comparison = 0
                if(a.bookPrice > b.bookPrice){
                    comparison=-1
                }
                    return comparison
                }
                this.setState({
                    books: books.sort(compare)
                })
        }
    }

    cartCountHandler = (clickedID,bookAvailable) => {
        let count = this.state.cartCounter;
        let doesShowWishlist = this.state.showWishlist;
        let doesDisableButton = this.state.disableButton;
        let clickedidArray = this.state.clickedId;
        clickedidArray.push(clickedID);
        console.log("click id is",clickedID);
        let doesShowCartCounter = this.state.showCartCounter;
        this.setState({
            cartCounter: count+1,
            clickedId: [...clickedidArray],
            showWishlist: !doesShowWishlist,
            disableButton: !doesDisableButton,
            showCartCounter: !doesShowCartCounter
        })
        var cart = {
            bookId: clickedID ,
            numOfCopies: bookAvailable
        }
       const response = AddCartRequestMethod(cart);
       response.then(res=>{
          console.log(res.data); 
       })
        console.log("counter", this.state.cartCounter)
    }
    searchHandler = (event) => {
        let search = event.target.value;
        console.log("searching for", search);
        if (search.toString().length >= 1) {
            const newData = this.state.books.filter(item => {
                return (
                    item.bookTitle.toLowerCase().indexOf(search.toLowerCase()) > -1 ||
                    item.authorName.toLowerCase().indexOf(search.toLowerCase()) > -1
                );
            })
            this.setState({
                isSearching: true,
                filterArray: newData,
                filterArrayCount: newData.length
            })
            console.log("filter array", this.state.filterArray);
        }
        else {
            this.setState({
                isSearching: false
            })
        }
    }
    componentDidMount() {
        getAllBooksRequestMethod()
            .then(response => {
                const books = response.data;
                this.setState({
                    books: books
                })
            })

        getBookCountRequestMethod()
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
                searchHandler={this.searchHandler}
                />
                {
                    this.state.showAddCartPage ?
                            <AddCartPage 
                            //showOrderPlacedPage = {this.state.showOrderPlacedPage}
                            //orderPlacedPageHandler = {this.orderPlacedPageHandler}
        

                            />
                       
                        :
                        <>
                             <div className='card-header'>
                                <div className="BookCard-Header">
                                    <h5>Books<span id='bookcountfont'>({this.state.NumOfBooks} items)</span></h5>
                                </div>
                                <div class="sort-by-div">
                                    <select onChange={this.sortingHandler} className="select-bar">
                                        <option >Sort By</option>
                                        <option>Price: high to low</option>
                                        <option>Price: low to high</option>
                                        <option>Newest arrivals</option>
                                    </select>
                                </div>
                            </div>
                            <BookCard 
                             books={currentPosts}
                            cartCounter={this.cartCountHandler} 
                            //books={this.state.books} text={this.state.text} 
                            bookCount={this.state.isSearching ? this.state.filterArrayCount : this.state.bookCount}
                            books={this.state.isSearching ? this.state.filterArray : currentPosts}
                            showWishlist={this.state.showWishlist} 
                            disableButton={this.state.disableButton} 
                            clickedId={this.state.clickedId} 
                            />
                             <Pagination postsPerPage={this.state.postsPerPage}
                                totalPosts={this.state.isSearching ? this.state.filterArray :this.state.books.length}
                                paginateNumber={this.paginate} />
                        </>
                }
               
                <Footer />
            </div>
        );
    }
}
