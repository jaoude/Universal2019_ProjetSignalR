import React from 'react';
import HttpClient from '../httpRequests';
import './App.css';
import coffee from '../Assets/coffee.jpg';



class App extends React.Component {

    httpClient = new HttpClient(); 

    render() {
        return (
            
            <div className="App">
                <button className="MyOrders" style={{float: 'right'} } onClick={()=>this.showOrders()}>My Orders</button>
                <header className="App-header">
                    
                    <img className="Coffee-Logo" src={coffee} alt="logo" />

                    <p>Choose your Coffee :</p>

                    <select id="Coffees" ref={ref => this.Coffees_Ref = ref}>
                        <option value="Espresso">Espresso</option>
                        <option value="Latte">Latte</option>
                        <option value="Americano">Americano</option>
                        <option value="Cappucino">Cappucino</option>
                    </select>

                    <p>Choose the size :</p>

                    <select id="Sizes">
                        <option value="XL">XL</option>
                        <option value="L">L</option>
                        <option value="M">M</option>
                        <option value="S">S</option>
                    </select>
                   

                    <button className="order">Order</button>
                    <div id="orders"></div>
                   
                </header>
            </div>
        );
    }
    showOrders()
    {
    
    
        this.httpClient.get();

        var items = JSON.parse( localStorage[1])
        
    
      
      
   
        for (var i = 0 ; i<items.length;i++)
        {
            var coffee = this.httpClient.getCoffeeById(parseInt(items[i].coffeeId));
            console.log(coffee);
            var status = this.httpClient.getStatusById(parseInt(items[i].statusId));
            var div = document.getElementById("orders");
            console.log(div)
            var coffee_p = document.createElement("p");
            coffee_p.innerHTML ="<p>"+coffee+"</p>";
            var status_p = document.createElement("p");
            status_p.innerHTML ="<p>"+status+"</p>";

            div.append(coffee_p);
            div.append(status_p)

        }
    }
  
    
    CreatePostBody()
    {
        var coffee_type = document.getElementById("Coffees").options[document.getElementById("Coffees").options.selectedIndex].value
        
        var size =  document.getElementById("Sizes").options[document.getElementById("Sizes").options.selectedIndex].value;
       

        var coffee_id = this.httpClient.getCoffee(coffee_type);
        var obj = new Object();
   obj.CoffeeId =coffee_id;
   obj.ClientId = 1;
   obj.StatusId = 1;
   obj.Size = size;

   var body = JSON.stringify(obj);
   
   return body;
 
 

        

    }
}

export default App;