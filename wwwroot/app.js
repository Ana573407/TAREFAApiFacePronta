document.getElementById('userForm').addEventListener('submit', async function(event) {
  event.preventDefault();

  const form = this; 
  const nome = document.getElementById('nome').value.trim();
  const email = document.getElementById('email').value.trim();
  const senha = document.getElementById('senha').value.trim();
  const mensagemEl = document.getElementById('mensagem');

  try {
    const resposta = await fetch('http://localhost:5024/api/Facebook', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ Nome: nome, Email: email, Senha: senha })
    });

    if (!resposta.ok) {
      const erroDados = await resposta.json().catch(() => null);
      throw new Error(erroDados?.message || 'Erro ao salvar usuário');
    }

    const dados = await resposta.json();
    mensagemEl.style.color = 'green';
    mensagemEl.textContent = dados.message || 'Usuário cadastrado com sucesso!';

    form.reset();

    setTimeout(() => {
      window.location.href = 'fedd.html'; 
    }, 1500);

  } catch (error) {
    mensagemEl.style.color = 'red';
    mensagemEl.textContent = error.message;
  }
});

