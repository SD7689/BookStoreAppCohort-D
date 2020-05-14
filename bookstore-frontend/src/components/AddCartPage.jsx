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
//import { OrderPlaced } from './OrderPlaced'
import OrderPlaced from '../components/OrderPlaced'
import {getCartAddedCountRequestMethod,adCustomeDetailsRequestMethod, getCartValuesRequestMethod,deleteCartValueRequestMethod} from '../Services/CartServices';

export class AddCartPage extends Component {
    state = {
        showCustomerDetails: false,
        clickedId: [],
        showOrderPlacedPage: false,
        cartAddedCount:0,
         cart:[],
        name: "",
        phoneNumber: 0,
        pincode: 0,
        locality: "",
        city: "",
        address: "",
        landmark: "",
        type: "",
        email: "xyz"

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
            phoneNumber:phoneNumber
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

    componentDidMount(){
        Promise.all([getCartAddedCountRequestMethod(),getCartValuesRequestMethod()])
        .then(([cartAddedCountResult,getCartValues]) => {
            this.setState({
                cartAddedCount: cartAddedCountResult.data,
                cart : getCartValues.data
            })
        })
    }
    deleteCartHandler = async(id)=>{
        const response = deleteCartValueRequestMethod({ params: { cartId: id } });
         await response.then(res=>{
           console.log(res.data)
          const cartCountRes= getCartAddedCountRequestMethod();
          cartCountRes.then(
              res=>{
                  this.setState({
                      cartAddedCount : res.data
                  })
              }
          )
          const cartValuesRes= getCartValuesRequestMethod();
               cartValuesRes.then(
                   res=>{
                       this.setState({
                           cart : res.data
                       })
                   }
               )
           })
       }

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
                                            <h3>My Cart({this.state.cartAddedCount})</h3>
                                        </div>
                                        {
                                            this.state.cart.map(ele=>{
                                                return(
                                                    <div className="order-details-div">
                                                    <div className="img-book">
                                                        <img src={ele.bookImage} className="order-logo" />
                                                    </div>
                                                    <div className="book-details-div">
                                                        <div className="book-title-div">
                                                            <h4 >{ele.bookTitle}</h4>
                                                        </div>
                                                        <div className="author-name-div">
                                                <p>{ele.authorName}}</p>
                                                        </div>
                                                        <div className="book-price-div">
                                                <p>Rs.{ele.bookPrice}</p>
                                                        </div>
                                                        <div className="quantity-div">
                                                            <button className="minus-btn"><RemoveRoundedIcon className="icon" /></button>
                                                            {
        
                                                                <input type="text" className="input-type" />
                                                            }
                                                            <button className="plus-btn"><AddRoundedIcon className="icon" /></button>
                                                            <button className="remove-btn" onClick={()=>this.deleteCartHandler(ele.cartId)} >Remove</button>
                                                        </div>
                                                        
                                                    </div>
                                                </div>
                                                )})
                                        }

                                        <div className="continue-cart-div">
                                                <button className="continue-shopping-cart-button" onClick={this.customerDetailsShowHandler}> PLACE ORDER </button>
                                        </div>
                                    </div>
                                </Grid>
                                <Grid item xs={10}>
                                    <div className="Customer-address-div">
                                        <div className="address-title">
                                            <h3>Customer Details</h3>
                                        </div>
                                        {
                                            this.state.showCustomerDetails?
                                            <>
                                            <div className="address-form">
                                            <div className="row-1">
                                                <TextField className="text-field" label="Name" variant="outlined" onChange={this.nameHandler} />
                                                <TextField className="text-field" id="outlined-basic" label="Phone Number" variant="outlined" onChange={this.phoneNumberHandler}/>
                                            </div>
                                            <div className="row-2">
                                                <TextField className="text-field" id="outlined-basic" label="Pin Code" variant="outlined" onChange={this.pincodeHandler}/>
                                                <TextField className="text-field" id="outlined-basic" label="Locality" variant="outlined" onChange={this.localityHandler}/>
                                            </div>
                                            <div className="row-3">
                                                <TextField className="text-field-address" id="outlined-basic" label="Address" variant="outlined" onChange={this.addressHandler} />
                                            </div>
                                            <div className="row-4">
                                                <TextField className="text-field" id="outlined-basic" label="City/Town" variant="outlined" onChange={this.cityHandler}/>
                                                <TextField className="text-field" id="outlined-basic" label="Landmark" variant="outlined" onChange={this.landmarkHandler}/>
                                            </div>
                                            <div className="radio-div">
                                                <h4>Type</h4>
                                                <div className="radio-values">
                                                    <RadioGroup>
                                                        <FormControlLabel value="Home" control={<Radio color="primary" />} label="Home" onChange={this.typeHandler}/>
                                                        <FormControlLabel value="Work" control={<Radio color="primary" />} label="Work" onChange={this.typeHandler}/>
                                                        <FormControlLabel value="Other" control={<Radio color="primary" />} label="Other" onChange={this.typeHandler}/>
                                                    </RadioGroup>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="continue-details-div">
                                        <button className="continue-shopping-details-button" onClick={this.addCustomerDetailsHandler}> CONTINUE </button>
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
                                            <button className="checkout-button" 
                                            onClick={this.props.orderPlacedPageHandler}
                                            >CHECKOUT</button>
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