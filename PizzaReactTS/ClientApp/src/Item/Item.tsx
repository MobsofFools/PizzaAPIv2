import Button from '@material-ui/core/Button';
//Types
import {CartItemType} from '../Menu/Menu';
//Styles
import {Wrapper} from './Item.styles';

type Props = {
    item: CartItemType;
    handleAddToCart: (clickedItem: CartItemType) => void;
}

const Item: React.FC<Props> = ({item, handleAddToCart}) => (
    <Wrapper>
        <img src={item.recipeImgSrc} alt={item.recipeName} />
        <div>
            <h3>{item.recipeName}</h3>
            <h4>${item.recipePrice}</h4>
        </div>
        <Button onClick={()=> handleAddToCart(item)}>Add to Cart</Button>
    </Wrapper>
);
export default Item;