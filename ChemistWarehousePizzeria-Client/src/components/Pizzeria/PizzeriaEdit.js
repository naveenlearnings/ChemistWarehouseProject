import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

export default function PizzeriaEdit() {
  const { id } = useParams();
  const [pizzeria, setPizzeria] = useState({
    id: null,
    name: '',
    menu: {
      pizzas: []
    }
  });

  const navigate = useNavigate();
  
  useEffect(() => {
    async function fetchPizzeria() {
        try{
            const response = await fetch(`https://localhost:7199/api/Pizzerias/${id}`);

            if (!response.ok) {
                throw new Error('Failed to fetch data');
              }

            const data = await response.json();
            setPizzeria(data);
        }
        catch(error){
            console.log(error);
        }
    }
    fetchPizzeria();
  }, [id]);

  function handlePizzaChange(pizzaId, updatedFields) {
    setPizzeria(prevPizzeria => {
      const updatedPizzas = prevPizzeria.menu.pizzas.map(pizza => {
        if (pizza.id === pizzaId) {
            console.log(updatedFields);
          return { ...pizza, ...updatedFields };
        } else {
          return pizza;
        }
      });
      return { ...prevPizzeria, menu: { ...prevPizzeria.menu, pizzas: updatedPizzas } };
    });
  }

  const saveChanges = async () => {
    try{
        console.log(pizzeria);
        const response = await fetch(`https://localhost:7199/api/Pizzerias/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(pizzeria)
        });

        if(!response.ok){
            throw new Error('Failed to edit. Try again later.');
        }

        navigate("/");
    }
    catch(error){
        console.log(error);
    }
  }

  return (
    <div className="container my-4">
      <div className="row">
        <div className="col-12">
          <h1>Edit Pizzeria</h1>
          <h2>{pizzeria.name}</h2>
        </div>
        <div className="col-md-8">
            {pizzeria.menu.pizzas.map(pizza => (
            <div style={{border: "1px solid black", padding: "20px", margin: "20px"}} className="form-group" key={pizza.id}>
                <label htmlFor={`name-${pizza.id}`}>Pizza name:</label>
                <input
                type="text"
                className="form-control"
                id={`name-${pizza.id}`}
                value={pizza.name}
                onChange={e => handlePizzaChange(pizza.id, { name: e.target.value })}
                />

                <label htmlFor={`toppings-${pizza.id}`}>Toppings:</label>
                <input
                type="text"
                className="form-control"
                id={`toppings-${pizza.id}`}
                value={pizza.toppings}
                onChange={e => handlePizzaChange(pizza.id, { toppings: e.target.value })}
                />

                <label htmlFor={`price-${pizza.id}`}>Price:</label>
                <input
                type="number"
                step="0.01"
                className="form-control"
                id={`price-${pizza.id}`}
                value={pizza.price}
                onChange={e => handlePizzaChange(pizza.id, { price: e.target.value })}
                />
            </div>
            ))}
        <button className="btn btn-primary" onClick={saveChanges}>Save changes</button>
        </div>
      </div>
    </div>
    );
}
