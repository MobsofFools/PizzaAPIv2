import {ChangeEvent, useState} from 'react';
import { CartItemType } from '../Menu/Menu';
import { Wrapper, HalfInput, FullInput, Label } from './Checkout.styles';
import {Center} from '../Cart/Cart.styles';
import Button from '@material-ui/core/Button';

type Props = {
    cartItems: CartItemType[];
    clearCart: () => void;
    closeCart: () => void;
    closeCheckout: () => void;
    passOrderId: (id:string) => void;
    openPopup: () => void;
    
}

const Checkout: React.FC<Props> = ({ cartItems, clearCart, closeCart, closeCheckout, passOrderId, openPopup }) => {
    
    const [fName, setfName]= useState("");
    const [lName, setlName]= useState("");
    const [address, setAddress]= useState("");
    const [city, setCity]= useState("");
    const [postal, setPostal]= useState("");
    const [prov, setProv]= useState("");
    const [email, setEmail]= useState("");
    
    const calculateTotal = (items: CartItemType[]) =>
        items.reduce((tot: number, item) => tot + item.amount * item.recipePrice, 0);     

    const afterTax = (calculateTotal(cartItems)*1.05).toFixed(2);

    const hfName = (event:ChangeEvent<HTMLInputElement>) => {
        setfName(event.target.value);
    }
    const hlName = (event:ChangeEvent<HTMLInputElement>) => {
        setlName(event.target.value);
    }
    const hAddress = (event:ChangeEvent<HTMLInputElement>) => {
        setAddress(event.target.value);
    }
    const hCity = (event:ChangeEvent<HTMLInputElement>) => {
        setCity(event.target.value);
    }
    const hPostal = (event:ChangeEvent<HTMLInputElement>) => {
        setPostal(event.target.value);
    }
    const hProv = (event:ChangeEvent<HTMLInputElement>) => {
        setProv(event.target.value);
    }
    const hEmail = (event:ChangeEvent<HTMLInputElement>) => {
        setEmail(event.target.value);
    }
    //Normally all of this would be JSON.stringify(type)
    
    const handleCheckout = () => {
        const body = '{"customerEmail":' + JSON.stringify(email)+'}';
        fetch('https://localhost:44379/P/Check',{
            method:'POST',
            headers: {'Content-Type':'application/json'},
            body: body
        }).then(res => res.json()).then(data => checkID(data));
    }
    
    function checkID(id: number) {
        if(id === 0)
        {
            console.log("none");
            newCustomer();
        }
        else
        {
            console.log("exists", id);
            newOrder(id.toString());
        }
    }
    const newCustomer = () => {
        const cust = '{"customerFName":'+
        JSON.stringify(fName)+',"customerLName":'+
        JSON.stringify(lName)+',"customerAddress":'+
        JSON.stringify(address)+',"customerCity":'+
        JSON.stringify(city)+',"customerPostal":'+
        JSON.stringify(postal)+',"customerProvince":'+
        JSON.stringify(prov)+',"customerEmail":'+
        JSON.stringify(email)+'}';
        console.log(cust);
        fetch('https://localhost:44379/Customers', {
                method: 'POST',
                headers:{'Content-Type': 'application/json'},
                body: cust
            }).then(response => response.json())
            .then(data => {newOrder(data.customerId);
            }).catch((error) => {
                console.error('Error:', error);
            });
    }
    const newOrder = (id: string) => {
        console.log("custid: "+ id);
        const ord = '{"customerId":'+JSON.stringify(id)+',"total":'+afterTax+'}';
        fetch('https://localhost:44379/Orders', {
            method: 'POST',
            headers:{'Content-Type': 'application/json'},
            body:ord
        }).then(response => response.json())
        .then(data => handleCheckoutItems(data.orderId))
        .catch((error) => {
            console.error('Error:', error);
        });
    }

    const handleCheckoutItems = (orderid: string) => {
        console.log("OrderId: "+orderid);
        cartItems.forEach(item => {
            const itemjson = '{"orderId":'+JSON.stringify(orderid)+
                             ',"recipeId":'+ JSON.stringify(item.recipeId)+
                             ',"quantity":'+JSON.stringify(item.amount)+'}';
            console.log(itemjson);
            fetch('https://localhost:44379/Items', {
                method:'POST',
                headers:{'Content-Type': 'application/json'},
                body: itemjson
            })
            .then(response => response.json())
            .then(data => console.log(data))
            .catch((error) => {
                console.error('Error:', error);
            });
        });
        finishOrder(orderid);   
    }
    const finishOrder = (orderid:string) => {
        passOrderId(orderid);
        clearCart();
        closeCart();
        closeCheckout();
        openPopup();
    }
    
    return (
        <Wrapper>
            <h2>Checkout</h2>
            <form>
                <Label>Required</Label><br/>
                <HalfInput
                    required id="standard-required"
                    label="First Name"
                    variant="outlined"
                    value={fName}
                    onChange={hfName}
                />
                <HalfInput
                    id="standard"
                    label="Last Name"
                    variant="outlined"
                    value={lName}
                    onChange={hlName}
                />
                <Label>Required</Label><br/>
                <HalfInput
                    required id="standard-required"
                    label="Email"
                    variant="outlined"
                    value={email}
                    onChange={hEmail}
                />
                <HalfInput
                    id="standard"
                    label="Postal Code"
                    variant="outlined"
                    value={postal}
                    onChange={hPostal}
                    inputProps={{maxLength: 6}}
                />
                <FullInput
                    id="standard"
                    label="Address"
                    variant="outlined"
                    value={address}
                    onChange={hAddress}
                />
                <HalfInput
                    id="standard"
                    label="City"
                    variant="outlined"
                    value={city}
                    onChange={hCity}
                />
                <HalfInput
                    id="standard"
                    label="Province"
                    variant="outlined"
                    value={prov}
                    onChange={hProv}
                />

            </form>
            <h3>Total: ${afterTax}</h3>
            <Center>
                <Button variant="contained" color="primary" onClick={handleCheckout}>Checkout</Button>
            </Center>
        </Wrapper>
    );
}
export default Checkout;