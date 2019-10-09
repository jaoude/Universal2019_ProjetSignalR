import React from 'react';
import HttpClient from '../httpRequests';
import './App.css';
import coffee from '../Assets/coffee.jpg';

class App extends React.Component {

    httpClient = new HttpClient(); 

    render() {
        return (
            <div className="App">
                <header className="App-header">
                    <img className="Coffee-Logo" src={coffee} alt="logo" />

                    <p>Choose your Coffee :</p>

                    <select name="Coffees">
                        <option value="Cappucino">Cappucino</option>
                        <option value="Frappucino">Frappucino</option>
                        <option value="Chibelino">Chibelino</option>
                        <option value="Latte">Latte</option>
                    </select>

                    <p>Choose the size :</p>

                    <select name="Coffees">
                        <option value="XL">XL</option>
                        <option value="L">L</option>
                        <option value="M">M</option>
                        <option value="S">S</option>
                    </select>

                    <button onClick={this.httpClient.get}>Order</button>
                </header>
            </div>
        );
    }
}

export default App;