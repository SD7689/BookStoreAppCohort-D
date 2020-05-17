import React,{ Component } from 'react';
import {AddUserRequestMethod} from '../Services/LoginService'

export class Login extends Component {
    constructor(props) {
        super(props)
        this.state = {
            email: "",
            password: ""
        }
    }
    handleEmailChange = (event) => {
        const email = event.target.value;
        this.setState({
            email: email
        })
        console.log("email", this.state.email)
    }
    handlePasswordChange = (event) => {
        const password = event.target.value;
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
    const response = AddUserRequestMethod(data);
    response.then(res => {
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
                        <div className="email-div">
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