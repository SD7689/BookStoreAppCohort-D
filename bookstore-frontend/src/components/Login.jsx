import React, { Component } from 'react';
import axios from 'axios';
import {AddUserRequestMethod} from '../Services/LoginService'

export class Login extends Component {
    
        state = {
            email: "",
            password: ""
        }
    
    handleEmailChange = (event) => {
       let email = event.target.value;
        this.setState({
            email: email
        })
        console.log("email", this.state.email)
    }
    handlePasswordChange = (event) => {
        let password = event.target.value;
        this.setState({
            password: password
        })
        console.log("password", this.state.password)
    }
    handleSubmitButton = (event) => {
        event.preventDefault();
        var data = {
            email: this.state.email,
            password: this.state.password

        }
    sessionStorage.setItem("email",this.state.email);
    AddUserRequestMethod(data).then(res => {
        console.log("Email is", res.data)
      if (res.data == data.email){
        this.props.history.push('/dashboard');
      }
      
    }).catch(() => {
      alert("email or password is incorrect");
     
    })
  }
  
        //console.log("data", data);
        //console.log("status", this.state.email, this.state.password);
    
    render() {
        return (
            <div className="main-div">
                <div className="test">
                    <div className="login-div">Login Form</div>
                    <div className="main-Test-div">

                        <div className="email-div">
                            <input type="email" className="input-email-div" placeholder="Email" onChange={this.handleEmailChange} />
                        </div>
                        <div className="password-div">
                            <input type="password" className="input-email-div" placeholder="Password" onChange={this.handlePasswordChange} />
                        </div>

                    </div>
                    <div className="app-button">
                        <button className="submit" onClick={this.handleSubmitButton}>Submit</button>
                    </div>
                    <div className="links">
                        <a href="/Sign-up">Sign up  |  </a>
                        <a href="/Sign-up"> Forgot Password</a>
                    </div>
                </div>
            </div>

        )
    

    }

}