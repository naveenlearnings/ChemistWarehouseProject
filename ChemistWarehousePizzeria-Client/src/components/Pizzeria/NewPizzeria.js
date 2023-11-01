export default function NewPizzeria(){
    return (
      <>
        <h3 className="m-5">I will outline the procedure here on how to create a new Pizzeria in multilple locations.</h3>
        <ul className="list-group list-group-flush">
          <li className="list-group-item">Load locations from the LocationController Get endpoint in useEffect</li>
          <li className="list-group-item">Load Pizza list from the PizzaController Get endpoint in useEffect</li>
  
          <li className="list-group-item">In UI create separate dropdowns for location and pizza list and bind them to the collections</li>
          <li className="list-group-item">Allow multiple selection in both dropdowns</li>
          <li className="list-group-item">Add an input field to specify the Pizzeria name</li>
  
          <li className="list-group-item">Add a button at the bottom to save this new Pizzeria</li>
          <li className="list-group-item">On Clicking Save button, create a json object and send it to the POST endpoint on PizzeriaController</li>
          <li className="list-group-item">On the server side, call the PizzeraService and through PizzeriaRepositiry save it to the database.</li>
        </ul>
      </>
    );
  }
  