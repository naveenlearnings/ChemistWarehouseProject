import { Link } from "react-router-dom";

export default function Order(){
    return (
        <>
        <h2>Thank you for placing your order</h2>
        <h5>Your order is:</h5>
        <ul>
            <li>Bla...</li>
            <li>Bla...</li>
            <li>Bla...</li>
            <li>Bla...</li>
        </ul>
        <h4>Total price is: "Get the value from redux or common conext"</h4>
        <Link className="btn btn-primary" to="/">Place Another Order?</Link>
        </>
    )
}