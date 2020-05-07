import React,{Component} from 'react';
import {Header} from './Header';
import {Footer} from './Footer';

export class DashBoard extends Component {
    render()
    {
        return (
           <div className ='dashboard-div'>
               <Header/>
               <Footer/>
           </div>
        );
    }
}
