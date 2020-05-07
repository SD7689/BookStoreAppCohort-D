import React,{Component} from 'react';
import MenuBookRoundedIcon from '@material-ui/icons/MenuBookRounded';
import AddShoppingCartTwoToneIcon from '@material-ui/icons/AddShoppingCartTwoTone';

export class Header extends Component {
    render()
    {
        return (
            <div className ="topnav" id="myTopnav">
                <div className='book-icon'>
                <MenuBookRoundedIcon fontSize='large'/>
                </div>
                <div className ='book-title'>
                <h3  className="logo-title">Book Store</h3>
                </div>
                <div className='search-bar'>
                <input className ='search' type="text" placeholder="Search..">
                    </input>
                </div>
                <div className='cart-div'>
                    <h3>Cart</h3>
                    <div className='cart-icon'>
                    <AddShoppingCartTwoToneIcon fontSize='medium'/>
                    </div>
                </div>
            </div>
        );
    }
}
