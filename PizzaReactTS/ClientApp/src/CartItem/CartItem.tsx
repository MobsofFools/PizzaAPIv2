import Button from '@material-ui/core/Button';
//Types
import {CartItemType} from '../Menu/Menu';
//Styles
import {Wrapper} from './CartItem.styles';

type Props = {
    item: CartItemType;
    addToCart: (clickedItem: CartItemType) => void;
    removeFromCart: (recipeId: number) => void;
}

const CartItem: React.FC<Props> = ({item, addToCart, removeFromCart}) => (
    <Wrapper>
        <div>
            <h3>{item.recipeName}</h3>
            <div className="information">
                <p>Price: ${item.recipePrice}</p>
                <p>Total: ${(item.amount * item.recipePrice).toFixed(2)}</p>
            </div>
            <div className="buttons">
                <Button 
                    size="small" 
                    disableElevation
                    variant="contained"
                    onClick={() => removeFromCart(item.recipeId)}
                >-</Button>
            <p>{item.amount}</p>
            <Button 
                    size="small" 
                    disableElevation
                    variant="contained"
                    onClick={() => addToCart(item)}
                >+</Button>
            </div>
        </div> 
        <img src={item.recipeImgSrc} alt={item.recipeName} />
    </Wrapper>
);

export default CartItem;