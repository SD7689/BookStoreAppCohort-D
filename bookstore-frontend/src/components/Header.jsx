import React, { Component } from 'react';
import MenuBookRoundedIcon from '@material-ui/icons/MenuBookRounded';
import AddShoppingCartTwoToneIcon from '@material-ui/icons/AddShoppingCartTwoTone';
import { Search } from '@material-ui/icons'
import { TextField, InputAdornment, Badge } from '@material-ui/core';


export class Header extends Component {
    render() {
        return (
            <div className="topnav" id="myTopnav">
                <div className='book-icon'>
                    <MenuBookRoundedIcon className="bookicon" />
                </div>
                <div className='book-title'>
                    <h2 className="logo-title">BookStore</h2>
                </div>
                <div className='search-bar'>
                    <TextField
                        className='search'
                        onChange={this.props.searchHandler}
                        InputProps={{
                            startAdornment: (
                               
                                <InputAdornment className="search-icon" position="start">
                                    <Search />
                                </InputAdornment>
                            ),
                        }}
                        id="outlined-basic"
                        placeholder='Search...'
                    />
                </div>
                <div className='cart-div'>

                    <h3 className="cart-h4">Cart</h3>
                   
                                {/* <div className='cart-icon-div'>
                                    <button className="cart-button"></button>
                                </div> */}
                                <Badge className ="cart-icon-div" badgeContent= {this.props.cartCount}>
                                
                                <AddShoppingCartTwoToneIcon className="cart-icon" fontSize='medium'  onClick={this.props.showAddCartPage} />
                                </Badge>
                           
                </div>
            </div>
        );
    }
}
