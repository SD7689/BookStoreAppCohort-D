import React, { Component } from 'react';
import logo from '../logo.svg';
import Container from '@material-ui/core/Container';

export class BookCard extends Component {
    render() {
        return (
            <Container maxWidth="lg">
                <div className="card-container">
                    {
                        this.props.books.map((ele) => {
                            return (
                                <div className="book-card-div">
                                    <img src={ ele.bookImage } className="App-logo" />
                                    <div className="book-item-info">
                                        <div className="book-title-div">
                                            <h4 >{ele.bookTitle}</h4>
                                        </div>
                                        <div className="author-name-div">
                                            <p>{ele.autherName}</p>
                                        </div>
                                        <div className="book-price-div">
                                            <p>Rs. {ele.bookPrice}/-</p>
                                        </div>
                                    </div>
                                    <div className="button-div">
                                        <button className="add-bag-button" onClick={this.props.cartCountHandler}>Add To Bag</button>
                                        <button className="wishlist-button">Wishlist</button>
                                    </div>
                                </div>
                            );
                        })
                    }
                </div>
            </Container>
           
        );
    }
}