import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import PizzeriaList from "./Pizzeria/PizzeriaList";
import Layout from './Common/Layout';
import PizzeriaEdit from './Pizzeria/PizzeriaEdit';
import NewPizzeria from './Pizzeria/NewPizzeria';
import Order from './Common/Order/Order';

import "react-toastify/dist/ReactToastify.css";

export default function App() {
  return (
    <Router>
      <Layout>
        <Routes insideRouter={true}>
          <Route exact path="/" element={<PizzeriaList/>}/>
          <Route path="/pizzeria/:id" element={<PizzeriaEdit/>}/>
          <Route path="/Pizzeria/new" element={<NewPizzeria/>}/>
          <Route path="/Order" element={<Order/>}/>
          {/* <Route path="*" element={<NotFound/>}/> */}
        </Routes>
      </Layout>
    </Router>
  );
}