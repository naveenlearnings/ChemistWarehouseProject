import styles from "./PizzeriaList.module.css";

export default function Pizza(props) {
  const { pizzeria, pizza, orderPizza, toggleTopping} = props;

  return (
  <div>
    <h6>{pizza.name}</h6>
    <p>{pizza.toppings}</p>
    <p>Price: ${pizza.price}</p>
    <div className="row">
      <div className="col-md-6">
        <button className="btn btn-primary btn-sm" onClick={() => orderPizza(pizza)}>
          Add to Order
        </button>
      </div>
      <div className="col-md-6">
        Toppings will be charged $1 extra:
        {pizza.extraToppings.map((topping) => {
          return (
            <button
              key={topping.name}
              onClick={() => toggleTopping(pizzeria, pizza, topping)}
              className={"btn " + (topping.isSelected ? "btn-primary btn-sm" : "btn-secondary btn-sm")}
              style={{marginLeft: "5px"}}
            >
              {topping.name}
            </button>
          );
        })}
      </div>
    </div>
  </div>
  );
}
