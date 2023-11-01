import React from 'react';
import { screen, render, waitFor } from '@testing-library/react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import PizzeriaList from "../components/pizzeria/pizzeriaList";
import { createServer } from "miragejs";
import userEvent from "@testing-library/user-event";

let pizzeriaList = null;

let server;
let setupServer = () => {
    server = createServer({
      routes() {
        //Practically we will not harcode the complete URL, we will use a base url from some configuration component using
        // the environment varaiable.
        this.get(`https://localhost:7199/api/Pizzerias`, () => {
          return pizzeriaList;
        });
    }});
};

let teardownServer = () => {
    pizzeriaList = null;
    server.shutdown();
  };
  
describe('PizzeriaList', () => {
    beforeEach(async () => {
        jest.resetModules();
        setupServer();
        pizzeriaList = [
            {
              "id": 1,
              "name": "Preston Pizzeria",
              "locationId": 1,
              "location": {
                "id": 1,
                "name": "Preston"
              },
              "menu": {
                "id": 1,
                "name": "Main Menu",
                "pizzeriaId": null,
                "pizzas": [
                  {
                    "id": 1,
                    "name": "Capricciosa",
                    "locationId": 1,
                    "toppings": "Cheese, Ham, Mushrooms, Olives",
                    "quentity": 0,
                    "price": 20.00
                  },
                  {
                    "id": 2,
                    "name": "Mexicana",
                    "locationId": 1,
                    "toppings": "Cheese, Salami, Capsicum, Chilli",
                    "quentity": 0,
                    "price": 18.00
                  },
                  {
                    "id": 3,
                    "name": "Margherita",
                    "locationId": 1,
                    "toppings": "Cheese, Spinach, Ricotta, Cherry Tomatoes",
                    "quentity": 0,
                    "price": 22.00
                  }
                ]
              }
            },
            {
              "id": 2,
              "name": "Southbank Pizzeria",
              "locationId": 2,
              "location": {
                "id": 2,
                "name": "Southbank"
              },
              "menu": {
                "id": 2,
                "name": "Main Menu",
                "pizzeriaId": null,
                "pizzas": [
                  {
                    "id": 1,
                    "name": "Capricciosa",
                    "locationId": 2,
                    "toppings": "Cheese, Ham, Mushrooms, Olives",
                    "quentity": 0,
                    "price": 23.00
                  },
                  {
                    "id": 4,
                    "name": "Vegetarian1",
                    "locationId": 2,
                    "toppings": "Cheese, Mushrooms, Capsicum, Onion, Olives",
                    "quentity": 0,
                    "price": 17.00
                  }
                ]
              }
            }
          ];
      });
    
      afterEach(() => {
        teardownServer();
      });

    it('renders correctly', async () => {
        const pizzeriaList = render(
        <Router>
            <PizzeriaList />
        </Router>
        );
        expect(pizzeriaList).toMatchSnapshot();
    });

    it("calculates correct price", async ()=> {
        render(
            <Router>
                <PizzeriaList/>
            </Router>
        );
        expect(screen.getByRole('heading', {  name: /number of pizzas ordered/i})).toBeInTheDocument();
        await waitFor(()=>{
            expect(screen.getByText(/Margherita/)).toBeInTheDocument();
            expect(screen.getByRole('heading', {  name: /total price: \$0/i})).toBeInTheDocument();
            const addBtns = screen.getAllByRole('button', {  name: /add to order/i});
            userEvent.click(addBtns[0]);
            expect(screen.getByRole('heading', {  name: /total price: \$20/i})).toBeInTheDocument();
        });
    });
});
