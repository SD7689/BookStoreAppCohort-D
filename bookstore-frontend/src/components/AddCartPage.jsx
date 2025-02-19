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
import { getCartAddedCountRequestMethod, adCustomeDetailsRequestMethod, getCartValuesRequestMethod, deleteCartValueRequestMethod } from '../Services/CartServices';
import OrderPlaced from './OrderPlaced';


export class AddCartPage extends Component {
    state = {
        showCustomerDetails: false,
        showOrderSummery: false,
        clickedId: [],
        showOrderPlacedPage: false,
        cartAddedCount: 0,
        cart: [],
        name: "",
        phoneNumber: 0,
        pincode: 0,
        locality: "",
        city: "",
        address: "",
        landmark: "",
        type: "",
        email: "cohortD",
        sameBook: 1

    }
    nameHandler = (event) => {
        const name = event.target.value;
        console.log("name", name);
        this.setState({
            name: name,
        })
    }
    phoneNumberHandler = (event) => {
        const phoneNumber = event.target.value;
        console.log('phoneNumber', phoneNumber)
        this.setState({
            phoneNumber: phoneNumber
        })
    }

    pincodeHandler = (event) => {
        const pincode = event.target.value;
        console.log("pincode", pincode);
        this.setState({
            pincode: pincode
        })
    }
    localityHandler = (event) => {
        const locality = event.target.value;
        console.log('locality', locality)
        this.setState({
            locality: locality
        })
    }
    cityHandler = (event) => {
        const city = event.target.value;
        console.log("city", city);
        this.setState({
            city: city,
        })
    }
    addressHandler = (event) => {
        const address = event.target.value;
        console.log('address', address)
        this.setState({
            address: address
        })
    }
    landmarkHandler = (event) => {
        const landmark = event.target.value;
        console.log("landmark", landmark);
        this.setState({
            landmark: landmark,
        })
    }
    typeHandler = (event) => {
        const type = event.target.value;
        console.log('type', type)
        this.setState({
            type: type
        })
    }
    addCustomerDetailsHandler = (event) => {
        event.preventDefault();
        //const email = window.sessionStorage.getItem('email');
        //console.log(`email is ${email}`);
        var data = {
            email: this.state.email,
            fullName: this.state.name,
            phoneNumber: this.state.phoneNumber,
            address: this.state.address,
            pincode: this.state.pincode,
            citytown: this.state.city,
            landmark: this.state.landmark,
            addressType: this.state.type
        }
        console.log(data);
        const response = adCustomeDetailsRequestMethod(data);
        response.then(res => {
            console.log(res.data);
        })

    }
    customerDetailsShowHandler = async () => {
        let doesShowCustomerDetails = this.state.showCustomerDetails;
        await this.setState({
            showCustomerDetails: !doesShowCustomerDetails
        })
    }
    orderSummeryShowHandler = async () => {
        let doesShowOrderSummery = this.state.showOrderSummery;
        await this.setState({
            showOrderSummery: !doesShowOrderSummery
        })
    }

    componentDidMount() {
        Promise.all([getCartAddedCountRequestMethod(), getCartValuesRequestMethod()])
            .then(([cartAddedCountResult, getCartValues]) => {
                this.setState({
                    cartAddedCount: cartAddedCountResult.data,
                    cart: getCartValues.data
                })
            })
    }
    deleteCartHandler = async (id) => {
        const response = deleteCartValueRequestMethod({ params: { cartId: id } });
        await response.then(res => {
            console.log(res.data)
            const cartCountRes = getCartAddedCountRequestMethod();
            cartCountRes.then(
                res => {
                    this.setState({
                        cartAddedCount: res.data
                    })
                }
            )
            const cartValuesRes = getCartValuesRequestMethod();
            cartValuesRes.then(
                res => {
                    this.setState({
                        cart: res.data
                    })
                }
            )
        })
    }
    sameBookAddHandler = async (cartId) => {
        let count = this.state.sameBook;
        // this.state.cart.map((ele) =>{
        //     e=ele.cartId
        // })
        await this.setState({
            sameBook: count + 1
        })
    }
    sameBookRemoveHandler = async (id) => {
        let count = this.state.sameBook;
        // const response = removeCartMethod({ params: { cartId: id } });
        // await response.then(res => {
            this.setState({
                sameBook: count - 1
            })
        
    }
    orderPlacedPageHandler = async () => {
        let doesShowOrderPlacedPage = this.state.showOrderPlacedPage;
        await this.setState({
            showOrderPlacedPage: !doesShowOrderPlacedPage
        })
    }
    render() {

        return (
            <>
           {
                    this.state.showOrderPlacedPage ?
                        <OrderPlaced />
                        :
                        <div className="cart-component">
                            <Container maxWidth="lg">
                                <div className="grid-div">
                                    <Grid container spacing={5}>
                                        <Grid item xs={10}>
                                            <div className="cart-order">
                                                <div className="cart-title-div">
                                                    <h3 className="my-cart-h4">My Cart({this.state.cartAddedCount})</h3>
                                                </div>
                                                {
                                                    
                                                    this.state.cart.map(ele => {
                                                        return (
                                                            <div className="order-details-div">
                                                                <div className="img-book">
                                                                    <img src={ele.bookImage} className="order-logo" />
                                                                </div>
                                                                <div className="book-details-div">
                                                                    <div className="book-title-div">
                                                                        <h4 className="h4-div">{ele.bookTitle}</h4>
                                                                    </div>
                                                                    <div className="author-name-div">
                                                                        <p>{ele.authorName}</p>
                                                                    </div>
                                                                    <div className="book-price-div">
                                                                        <p>Rs.{ele.bookPrice}</p>
                                                                    </div>
                                                                    <div className="quantity-div">
                                                                        <button className="minus-btn" onClick={this.sameBookRemoveHandler}><RemoveRoundedIcon className="icon" /></button>
                                                                        
                                                                            <div className="input-type">
                                                                                {this.state.sameBook}
                                                                            </div>
                                                                            {/* <input type="text"  className="input-type"> */}
                                                                       
                                                                        <button className="plus-btn"onClick={this.sameBookAddHandler}><AddRoundedIcon className="icon" /></button>
                                                                        <button className="remove-btn" onClick={() => this.deleteCartHandler(ele.cartId)} >Remove</button>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                        )
                                                    })
                                                }
                                                {
                                                    this.state.cartAddedCount!=0?
                                                    <div className="continue-cart-div">
                                                    <button className="continue-shopping-cart-button" onClick={this.customerDetailsShowHandler}> PLACE ORDER </button>
                                                </div>: null
                                                }
                                                
                                            </div>
                                        </Grid>
                                        <Grid item xs={10}>
                                            <div className="Customer-address-div">
                                                <div className="address-title">
                                                    <h3 className="my-cart-h4">Customer Details</h3>
                                                </div>
                                                {
                                                    this.state.showCustomerDetails ?
                                                        <form action="" className=" p-5" name="myForm" id="f" onSubmit={this.addCustomerDetailsHandler}>
                                                            <div className="form-group">
                                                                <input type="text" placeholder='Name' id="name" className="form-control " onChange={this.nameHandler} />
                                                                <input type="text" placeholder='Phone number' id="phoneNumber" className="form-control " onChange={this.phoneNumberHandler} />
                                                            </div>
                                                            <div className="form-group">
                                                                <input type="text" placeholder='pincode' id="pincode" className="form-control " onChange={this.pincodeHandler} />
                                                                <input type="text" placeholder='locality' id="locality" className="form-control " onChange={this.localityHandler} />
                                                            </div>
                                                            <div className="form-group">
                                                                <input type="text" placeholder='city/town' id="city" className="form-control " onChange={this.cityHandler} />
                                                                <input type="text" placeholder='landmark' id="landmark" className="form-control " onChange={this.landmarkHandler} />
                                                            </div>
                                                            <div className="form-group">
                                                                <input type="text" placeholder='address' id="address" className="address-group " onChange={this.addressHandler} />
                                                            </div>
                                                            <div className="type-div">
                                                                <label>Type</label>
                                                                <RadioGroup row aria-label="position" name="position" defaultValue="top">
                                                                    <FormControlLabel value="home" control={<Radio color="primary" />} label="Home" onChange={this.typeHandler} />
                                                                    <FormControlLabel value="work" control={<Radio color="primary" />} label="Work" onChange={this.typeHandler} />
                                                                    <FormControlLabel value="other" control={<Radio color="primary" />} label="Other" onChange={this.typeHandler} />
                                                                </RadioGroup>
                                                            </div>

                                                            <div className='add-btn'>
                                                                <button type="submit" id="continue" className="address-button" onClick={this.orderSummeryShowHandler}>CONTINUE</button>
                                                            </div>
                                                        </form> : null
                                                }
                                            </div>
                                        </Grid>
                                        <Grid item xs={10}>
                                            <div className="order-sumary">
                                                <div className="cart-title-div">
                                                    <h3 className="my-cart-h4">Order Summary</h3>
                                                </div>
                                                {
                                                    this.state.showOrderSummery?
                                                    this.state.cart.map(ele => {
                                                        return (
                                                            <div className="order-details-div">
                                                                <div className="img-book">
                                                                    <img src={ele.bookImage} className="order-logo" />
                                                                </div>
                                                                <div className="book-details-div">
                                                                    <div className="book-title-div">
                                                                        <h4 >{ele.bookTitle}</h4>
                                                                    </div>
                                                                    <div className="author-name-div">
                                                                        <p>{ele.authorName}</p>
                                                                    </div>
                                                                    <div className="book-price-div">
                                                                        <p>Rs.{ele.bookPrice}</p>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        )
                                                    }):null
                                                }
                                                <div className="checkout-div">
                                                    <button className="checkout-button"
                                                        onClick={this.orderPlacedPageHandler}
                                                    >CHECKOUT</button>
                                                </div>
                                            </div>
                                        </Grid>
                                    </Grid>
                                </div>
                            </Container>
                        </div>
                }
            </>
        );
    }
}