import React,{Component} from 'react';
import MenuBookRoundedIcon from '@material-ui/icons/MenuBookRounded';
import AddShoppingCartTwoToneIcon from '@material-ui/icons/AddShoppingCartTwoTone';

export class Header extends Component {
    render()
    {
        return (
            <div className ="topnav" id="myTopnav">
                <div className='book-icon'>
                <MenuBookRoundedIcon className="bookicon"/>
                </div>
                <div className ='book-title'>
                <h2  className="logo-title">BookStore</h2>
                </div>
                <div className='search-bar'>
                <input className ='search' type="text" placeholder="Search..">
                    </input>
                </div>
                <div className='cart-div'>
                    <h3>Cart</h3>
                    <div className='cart-icon-div'>
                    <AddShoppingCartTwoToneIcon className="cart-icon" fontSize='medium'/>
                    </div>
                </div>
            </div>
        );
    }
}
