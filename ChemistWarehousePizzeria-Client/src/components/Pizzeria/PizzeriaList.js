import React, { useState, useEffect } from 'react';
import { useNavigate, Link } from "react-router-dom";
import Pizza from "./Pizza";
import styles from "./PizzeriaList.module.css";
import { v4 as uuidv4 } from 'uuid';
import { toast } from "react-toastify";

function PizzeriaList() {
  const [pizzerias, setPizzerias] = useState([]);
  const [orderList, setOrderList] = useState([]);
  const [totalPrice, setTotalPrice] = useState(0);

  const navigate = useNavigate();

  useEffect(() => {
    async function fetchData() {
      try {
        //Practically we will not harcode the complete URL, we will use a base url from some configuration component using
        // the environment varaiable.
        const response = await fetch('https://localhost:7199/api/Pizzerias', {
          method: 'GET',
          mode: "cors",
          headers: { "Content-Type": "application/json" },
        });

        if (!response.ok) {
          throw new Error('Failed to fetch data');
        }
        const pizzerias = await response.json();
        const pizzeriasWithExtraToppings = pizzerias.map(pizzeria => ({
          ...pizzeria,
          menu: {
            ...pizzeria.menu,
            pizzas: pizzeria.menu.pizzas.map(pizza => ({
              ...pizza,
              extraToppings: [{ name: "Cheese", isSelected: false }, { name: "Capsicum", isSelected: false }, { name: "Tomatoes", isSelected: false }, { name: "Olives", isSelected: false }]
            }))
          }
        }));

        setPizzerias(pizzeriasWithExtraToppings);

      } catch (error) {
        console.error(error)
      }
    }
    fetchData();
  }, []);

  const orderPizza = (pizza) => {
    orderList.push(pizza);
    alert("cart updated");
    toast.success("Cart Updated with new Pizza!", {
      position: toast.POSITION.TOP_RIGHT,
      autoClose: false
    });
    calculatePrice();
  }

  const calculatePrice = () => {
    let price = 0;
    orderList.forEach((pizza) => {
      price += pizza.price;
      if (pizza.extraToppings) {
        price += pizza.extraToppings.filter((topping) => topping.isSelected).length;
      }
    });

    setTotalPrice(price);
  };

  const toggleTopping = (pizzeria, pizza, topping) => {
    const updatedPizzerias = pizzerias.map((p) => {
      if (p.id === pizzeria.id) {
        const updatedPizzas = p.menu.pizzas.map((piz) => {
          if (piz.id === pizza.id) {
            const updatedToppings = piz.extraToppings.map((top) => {
              if (top.name === topping.name) {
                return { ...top, isSelected: !top.isSelected };
              }
              return top;
            });
            return { ...piz, extraToppings: updatedToppings };
          }
          return piz;
        });
        return { ...p, menu: { ...p.menu, pizzas: updatedPizzas } };
      }
      return p;
    });
    setPizzerias(updatedPizzerias);
  };

  const submitOrder = async () => {
    try {
      const pizzas = [];
      orderList.forEach((pizza) => {
        const pizzaDto = {
          Id: pizza.id,
          LocationId: pizza.locationId,
          Quentity: 1,
        }

        let toppings = [];

        if (pizza.extraToppings) {
          pizza.extraToppings.forEach((top) => {
            if (top.isSelected) {
              toppings.push(top.name);
            }
          });
        }

        if (toppings.length > 0) {
          pizzaDto.Toppings = toppings.join(",");
        }

        pizzas.push(pizzaDto);
      });

      const order = {
        Name: "Someone",
        Address: "7 Mckay St Broadview, 5083",
        Pizzas: pizzas,
      }

      //Practically we will not harcode the complete URL, we will use a base url from some configuration component using
      // the environment varaiable.
      const response = await fetch('https://localhost:7199/api/Orders', {
        method: 'POST',
        mode: "cors",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(order),
      });

      if (!response.ok) {
        throw new Error('Sorry, Order failed. Try again later.');
      }

      navigate("/Order");

    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div className="App">
    
      <main>
        {pizzerias.map(pizzeria => (
          <div key={pizzeria.id} className={`${styles.pizzaContainer} container`}>
            <div className=''>
              <div className='col-md'>
                <h4>{pizzeria.name}</h4>
                <h6>Location:{pizzeria.location.name}  <Link className='btn btn-link' to={`/pizzeria/${pizzeria.id}`}>Edit</Link> </h6>

              </div>

            </div>
            <div>
              {pizzeria.menu.pizzas.map(pizza => {
                return (
                  <Pizza key={uuidv4()} pizzeria={pizzeria} pizza={pizza} orderPizza={orderPizza} toggleTopping={toggleTopping} />
                )
              })}
            </div>
          </div>
        ))}

      </main>
      <header className="alert alert-primary" role="alert">
        <div className='container'>
          <div className='row'>
            <h5 className="right">Number of Pizzas Ordered: {orderList.length}</h5>
          </div>
          <div className='row'>
            <span> <h6>Total price: ${totalPrice}</h6> (including Tax)</span>
          </div>

          <div className='row'>
            <div className='col-md'>
              <button className='btn btn-primary btn-sm' onClick={submitOrder}>Submit Order</button>
            </div>
          </div>
        </div>
      </header>
    </div>
  );
}

export default PizzeriaList;
