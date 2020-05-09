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
                                    <img src={logo} className="App-logo" />
                                    <div className="book-item-info">
                                        <div className="book-title-div">
                                            <h4 >{ele.bookName}</h4>
                                        </div>
                                        <div className="author-name-div">
                                            <p>{ele.authorName}</p>
                                        </div>
                                        <div className="book-price-div">
                                            <p>{ele.price}</p>
                                        </div>
                                    </div>
                                    <div className="button-div">
                                        <button className="add-bag-button">Add To Bag</button>
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