import React,{Component} from 'react';
import './App.css';
import OrderPlaced from './components/OrderPlaced';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom'
import { DashBoard } from './components/DashBoard';
import {AddCartPage} from './components/AddCartPage';

class App extends Component {
  constructor(props) {
    super(props)
  }
  render() {
    return (
      <Router>
        <Switch>
          <Route path='/' component={DashBoard} exact />
          <Route path='/orderplaced' component={OrderPlaced} />
          <Route path='/addCartPage' component={AddCartPage} />
        </Switch>
      </Router>
    );
  }
}
export default App;
