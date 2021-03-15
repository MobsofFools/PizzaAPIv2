import Button from "@material-ui/core/Button";
import Grid from "@material-ui/core/Grid";
import { Link } from 'react-router-dom';
import { Wrapper } from './HeroSection.styles';

function HeroSection() {
    return (
        <Wrapper>
            <div className="hero-container">
                <Grid container justify="center">
                    <h1>Fake Pizza Near You</h1>
                </Grid>
                <div className="hero-btns">
                    <Button variant="contained" className="dom-red" component={Link} to={'/menu'}>Order Here</Button>
                </div>
            </div>
        </Wrapper>

    );
}

export default HeroSection;