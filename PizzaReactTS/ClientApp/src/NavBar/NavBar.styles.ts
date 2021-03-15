import styled from 'styled-components';

export const Theme = {
    colors: {
      bg: `#fff`,
      dark: `#006491`,
      light: `#EEEEEE`,
      red: `#ff5851`,
    },
    fonts: {
      body: `Arial, sans-serif`,
      heading: `Arial, sans-serif`,
    }
  }

export const Navb = styled.nav`
  background: ${Theme.colors.dark};
  font-family: ${Theme.fonts.heading};
  color: ${Theme.colors.light};
  display: flex;
  align-items: center;
  justify-content: space-around;
  width: 100vw;
  min-height: 5vh;
  margin-left: calc(-50vw + 50%);
  z-index:200;
  
  position: fixed;
  top:0px;
  left:0px;
  a { color: white; text-decoration: none; }
  
  `;

export const Brand = styled.a`
  font-weight: bold;
  font-style: italic;
  margin-left: 1rem;
  padding-right: 1rem;`;

export const Ul = styled.ul`
list-style-type: none;
li {
    display: block;
    float: left;
    padding: 5px 16px 5px 16px ;
    
}
`;