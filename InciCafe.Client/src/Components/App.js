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
                    <form>

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

                   

                    <button type="submit" onClick={()=>this.httpClient.post(()=>this.CreatePostBody())} className="order">Order</button>
                    <div id="orders"></div>
                    </form>
                   
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
            
            
            
            this.httpClient.getCoffeeById(items[i].coffeeId);
            this.httpClient.getStatusById(parseInt(items[i].statusId));


            var div = document.getElementById("orders");
            console.log(div)
            var coffee_p = document.createElement("p");
            coffee_p.innerHTML ="<p>"+localStorage[2]+"</p>";
            var status_p = document.createElement("p");
            status_p.innerHTML ="<p>"+localStorage[3]+"</p>";

            div.append(coffee_p);
            div.append(status_p)

        }
    }
  
    
    CreatePostBody()
    {
       
        var size =  document.getElementById("Sizes").options[document.getElementById("Sizes").options.selectedIndex].value;
       

    var coffee_id = document.getElementById("Coffees").options.selectedIndex;
    
    var obj = new Object();
   obj.CoffeeId = coffee_id+1;
   obj.ClientId = 1;
   obj.StatusId = 1;
   obj.Size = size;

   var body = JSON.stringify(obj);
   console.log(typeof(body))


   
   return body;
 
 

        

    }
}

export default App;