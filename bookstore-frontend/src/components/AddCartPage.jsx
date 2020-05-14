import React, { Component } from 'react';
import Grid from '@material-ui/core/Grid';
import { Header } from './Header';
import { Footer } from './Footer';
import logo from '../logo.svg';
import Container from '@material-ui/core/Container';
import TextField from '@material-ui/core/TextField';
import RadioGroup from '@material-ui/core/RadioGroup';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Radio from '@material-ui/core/Radio';
import RemoveRoundedIcon from '@material-ui/icons/RemoveRounded';
import AddRoundedIcon from '@material-ui/icons/AddRounded';
import Demobook from '../Asserts/Demobook.jpg'


export class AddCartPage extends Component {
    render() {

        return (
            <>
                <div className="cart-component">
                    <Container maxWidth="lg">
                        <div className="grid-div">
                            <Grid container spacing={5}>
                                <Grid item xs={10}>
                                    <div className="cart-order">
                                        <div className="cart-title-div">
                                            <h3>My Cart(1)</h3>
                                        </div>
                                        <div className="order-details-div">
                                            <div className="img-book">
                                                <img src={Demobook} className="order-logo" />
                                            </div>
                                            <div className="book-details-div">
                                                <div className="book-title-div">
                                                    <h4 >Harry Potter</h4>
                                                </div>
                                                <div className="author-name-div">
                                                    <p>J.K Rowling</p>
                                                </div>
                                                <div className="book-price-div">
                                                    <p>Rs. 800</p>
                                                </div>
                                                <div className="quantity-div">
                                                    <button className="minus-btn"><RemoveRoundedIcon className="icon" /></button>
                                                    {

                                                        <input type="text" className="input-type" />
                                                    }
                                                    <button className="plus-btn"><AddRoundedIcon className="icon" /></button>
                                                    <button className="remove-btn">Remove</button>
                                                </div>
                                                
                                            </div>
                                        </div>
                                        <div className="continue-cart-div">
                                                <button className="continue-shopping-cart-button" onClick={this.props.showCustomerDetails}> PLACE ORDER </button>
                                        </div>
                                    </div>
                                </Grid>
                                <Grid item xs={10}>
                                    <div className="Customer-address-div">
                                        <div className="address-title">
                                            <h3>Customer Details</h3>
                                        </div>
                                        {
                                            this.props.showDetails?
                                            <>
                                            <div className="address-form">
                                            <div className="row-1">
                                                <TextField className="text-field" label="Name" variant="outlined" />
                                                <TextField className="text-field" id="outlined-basic" label="Phone Number" variant="outlined" />
                                            </div>
                                            <div className="row-2">
                                                <TextField className="text-field" id="outlined-basic" label="Pin Code" variant="outlined" />
                                                <TextField className="text-field" id="outlined-basic" label="Locality" variant="outlined" />
                                            </div>
                                            <div className="row-3">
                                                <TextField className="text-field-address" id="outlined-basic" label="Address" variant="outlined" />
                                            </div>
                                            <div className="row-4">
                                                <TextField className="text-field" id="outlined-basic" label="City/Town" variant="outlined" />
                                                <TextField className="text-field" id="outlined-basic" label="Landmark" variant="outlined" />
                                            </div>
                                            <div className="radio-div">
                                                <h4>Type</h4>
                                                <div className="radio-values">
                                                    <RadioGroup>
                                                        <FormControlLabel value="end" control={<Radio color="primary" />} label="Home" />
                                                    </RadioGroup>
                                                    <RadioGroup>
                                                        <FormControlLabel value="end" control={<Radio color="primary" />} label="Work" />
                                                    </RadioGroup>
                                                    <RadioGroup>
                                                        <FormControlLabel value="end" control={<Radio color="primary" />} label="Other" />
                                                    </RadioGroup>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="continue-details-div">
                                        <button className="continue-shopping-details-button"> CONTINUE </button>
                                        </div>
                                        </>
                                        :
                                        null
                                        }
                                      
                                    </div>
                                </Grid>
                                <Grid item xs={10}>
                                    <div className="order-sumary">
                                        <div className="cart-title-div">
                                            <h3>Order Summary</h3>
                                        </div>
                                        <div className="order-details-div">
                                            <div className="img-book">
                                                <img src={Demobook} className="order-logo"/>
                                            </div>
                                            <div className="book-details-div">
                                                <div className="book-title-div">
                                                    <h4 >Harry Potter</h4>
                                                </div>
                                                <div className="author-name-div">
                                                    <p>J.K Rowling</p>
                                                </div>
                                                <div className="book-price-div">
                                                    <p>Rs. 800</p>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="checkout-div">
                                            <button className="checkout-button">CHECKOUT</button>
                                        </div>
                                    </div>
                                </Grid>
                            </Grid>
                        </div>
                    </Container>
                </div>

            </>
        );
    }
}