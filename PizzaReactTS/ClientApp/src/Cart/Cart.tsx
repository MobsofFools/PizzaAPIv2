import {useState} from 'react';
import Drawer from '@material-ui/core/Drawer';
import CartItem from '../CartItem/CartItem';
import Button from '@material-ui/core/Button';
//Styles
import { Wrapper, Right, Center } from './Cart.styles';
//Types
import {CartItemType} from '../Menu/Menu';
import Checkout from '../Checkout/Checkout';

type Props ={
    cartItems: CartItemType[];
    addToCart: (clickedItem: CartItemType) => void;
    removeFromCart: (recipeId: number) => void;
    clearCart: () => void;
    closeCart: () => void;
    passOrderId: (id: string) => void;
    openPopup:() => void;
    
}

const Cart: React.FC<Props> = ({cartItems, addToCart, removeFromCart, clearCart, closeCart, passOrderId, openPopup}) =>{
    const [checkoutOpen, setCheckoutOpen] = useState(false);
    const closeCheckout = () => setCheckoutOpen(false);
    const calculateTotal = (items: CartItemType[]) => 
        items.reduce((tot:number,item) => tot+item.amount*item.recipePrice,0)
    return(
        <Wrapper>
            <h2>Your Cart</h2>
            {cartItems.length === 0 ? <p>No items in cart</p> : null}
            {cartItems.map(item => (
                <CartItem
                    key={item.recipeId}
                    item={item}
                    addToCart={addToCart}
                    removeFromCart={removeFromCart}
                />
            ))}
            {cartItems.length === 0 ? null : (
            <>
            <Right>
                <h3>Subtotal: ${calculateTotal(cartItems).toFixed(2)}</h3>
                <h4>GST: ${(calculateTotal(cartItems)*0.05).toFixed(2)}</h4>
                <h2>Total: ${(calculateTotal(cartItems)*1.05).toFixed(2)}</h2>
            </Right>
            <Center>
                <Button variant="contained" color="primary" onClick={() => setCheckoutOpen(true)}>Proceed to checkout</Button>
            </Center>
            </>
            )}
            <Drawer anchor='left' open={checkoutOpen} onClose={()=> setCheckoutOpen(false)}>
                <Checkout
                    cartItems={cartItems}
                    clearCart={clearCart}
                    closeCart={closeCart}
                    closeCheckout={closeCheckout}
                    passOrderId={passOrderId}
                    openPopup={openPopup}
                />
            </Drawer>
        </Wrapper>
    );
}

export default Cart;