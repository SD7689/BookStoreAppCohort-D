import React from 'react';
import './App.css';
import {DashBoard} from './components/DashBoard';
import {AddCartPage} from './components/AddCartPage';

function App() {
  return (
    <div className="App">
      <AddCartPage/>
      {/* <DashBoard/> */}
    </div>
  );
}

export default App;
