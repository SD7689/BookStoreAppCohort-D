import React, { Component } from 'react';
import { Footer } from './Footer';
import { Header } from './Header';
import Celebration from '../Asserts/Celebration.png';

export default class OrderPlaced extends Component {
      
    continueShoppingButtonHandler = (event) => {
        window.location.reload("/dashboard");
    }
    render() {
        return (
            <>
                
                <div className="order-placed-container">
                    <div className="upper-image-div">
                        <img className="order-image-div" src={Celebration} />
                    </div>
                    <div className="order-successfull-div">
                        <h2>Order Placed Successfully</h2>
                    </div>
                    <div className="order-info-div">
                        <p className="order-info">Hurray!! your order is confirmed<br/>
                        your order id is #123456 save the order id<br/>
                        for further communication.
                        </p>
                    </div>
                    <div className="table-div">
                        <table>
                            <tr className="table-column">
                                <th>Email us</th>
                                <th>Contact us</th>
                                <th>Address</th>
                            </tr>
                            <tr className="table-data">
                                <td>cohort.d@gmail.com</td>
                                <td>+91 8562874557</td>
                                <td>BridgeLabz Solution<br />
                            HSR Layout, Near Central Silk Board.
                            </td>
                            </tr>
                        </table>
                    </div>
                    <div className="continue-shopping-button-div">
                        <button className="continue-shopping-button" onClick={this.continueShoppingButtonHandler}> CONTINUE SHOPPING</button>
                        </div>
                </div>

               
            </>
        );
    }
}