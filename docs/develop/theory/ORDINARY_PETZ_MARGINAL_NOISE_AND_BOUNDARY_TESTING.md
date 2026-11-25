# Ordinary Petz recovery under marginal-preserving noise and boundary testing

## 1. Scope and provenance

This volume owns the ordinary Petz recovery of a retained marginal under partial trace, its faithful regularization, and the resulting one-copy statistical experiments. The manuscript is an append-only reference input for the main trureturing repository, with generic-v1 digestion. Subsequent corrections and extensions belong after the final append anchor.

The ordinary proofs below synthesize the research manuscripts “Ordinary Petz at a singular joint reference under marginal-preserving faithful noise” and “Blind one-copy tests of the two-qubit Petz regularization” (25 November 2026). The source synchronization was implemented in an sshx worker using the first manuscript and the separately reviewed second manuscript supplied by the coordinator. Both companion exact symbolic replays were executed on the rational two-qubit data. The proofs in this volume have ordinary mathematical status. Formal coverage is recorded by the separate main-repository freezing and settlement ledger.

## 2. Setting and the accepted faithful tangent anchor

**定义 2.1（Actual recovery and deficit）。** Let $E,B$ be nonzero finite-dimensional complex Hilbert spaces, $m=\dim E$, $d=\dim B$, in factor order $E\otimes B$. Write $N=\operatorname{Tr}_E$. All traces are unnormalized, all logarithms natural, and the trace norm is full (unhalved). Let $Z,\rho$ be positive semidefinite trace-one joint matrices with $\operatorname{supp}\rho\subseteq\operatorname{supp} Z$ and $P=NZ>0$. Set $p=N\rho$. For any retained matrix $x$ define

$$
R_Z(x)=\sqrt Z(I_E\otimes P^{-1/2}xP^{-1/2})\sqrt Z,\qquad
\Delta=D(\rho\Vert Z)-D(p\Vert P),\qquad n=\|\rho-R_Z(p)\|_1.
$$

Here $D(A\Vert B)=\operatorname{Tr}A(\log A-\log B)$ on compatible supports and $+\infty$ when support containment fails, with $0\log 0=0$. Data processing gives $\Delta\ge0$. The partial trace identity gives $R_Z(P)=Z$ and $\operatorname{Tr}R_Z(x)=\operatorname{Tr}x$. The recovery formula uses the actual retained marginal $p$ of the source.

**注记 2.2（Pinned Lean anchor）。** PR 34116 merged at ec070acbd5dd7e8c5a729ebe8f8be01d063486e4. The accepted theorem D5.S3.Quantum.Recovery.PetzTangentTraceNorm.faithful_traceNorm_tangent quantifies over every nonempty finite environment index type $E$ with decidable equality, every complex matrix $H$ and every positive definite joint matrix $Z$ indexed by $\mathrm{Fin}\,2\times E$ with $\operatorname{Re}\operatorname{Tr}Z=1$. In the Lean factor order $B\otimes E$, put $P=\operatorname{partialTraceRight}Z$, $h=\operatorname{partialTraceRight}H$ and let $p_0,p_1$ be the two eigenvalues of $P$. Writing $\delta=2\sqrt{p_0p_1}$, the precise coefficient and conclusion are

$$
\begin{aligned}
\kappa(\delta)&=\begin{cases}1&\delta=1,\\ \max\{2,(3-\delta)/(1+\delta)\}&0<\delta<1,\end{cases}\\
\|H-R_Z(h)\|_1^2 &\le \kappa(\delta)
\operatorname{Re}\operatorname{Tr}\big(H^\dagger D\log_Z[H]-h^\dagger D\log_P[h]\big).
\end{aligned}
$$

The definition of $\kappa$ is parityMultiplier, with its exceptional coincident-node case. Here $D\log$ denotes the log derivative used by logDeriv, and $R_Z$ denotes partialTracePetz in Lean. Swapping the tensor factors by the permutation unitary identifies that setting with Definition 2.1. The exact merged [trace-norm theorem](https://github.com/the-omega-institute/trureturing/blob/ec070acbd5dd7e8c5a729ebe8f8be01d063486e4/D5/S3/Quantum/Recovery/NoncommutingQubit/PetzTangentTraceNorm.lean#L86) and [PR 34116](https://github.com/the-omega-institute/trureturing/pull/34116) supply the faithful anchor.

The proof consumes faithful_weighted_tangent, whose left side is $\sum_{ij}|(U^\dagger(H-R_Z(h))U)_{ij}|^2/((\lambda_i+\lambda_j)/2)$, for a joint diagonalizing unitary $U$ with eigenvalues $\lambda_i>0$, and whose right side is the same $\kappa$ times the BKM difference. Its entrywise physical arcsine bound uses paired_parity_bound, valid for complex $a,b,c,d$, real $g,\beta,\delta$ with $g>0$, $0<\delta\le1$, $g^2+\beta^2\le1$. Its precise inequality is

$$
|g(a+b)+\beta(c+d)|^2\le\kappa(\delta)\int_0^\infty\sqrt{1+t}
\left(\frac{|a/(1+t)+b\delta/(\delta^2+t)|^2}{2}
+\frac{|c(g+1)/(1+t)+d\delta(g+\delta)/(\delta^2+t)|^2}{2(g^2+t)}\right)dt.
$$

This gives the proof chain via [faithful_weighted_tangent and physical_entry_arcsine_and_bound](https://github.com/the-omega-institute/trureturing/blob/ec070acbd5dd7e8c5a729ebe8f8be01d063486e4/D5/S3/Quantum/Recovery/NoncommutingQubit/PetzTangentPhysical.lean#L720) and [paired_parity_bound](https://github.com/the-omega-institute/trureturing/blob/ec070acbd5dd7e8c5a729ebe8f8be01d063486e4/D5/S3/Quantum/Recovery/NoncommutingQubit/PetzTangentReciprocalGram.lean#L752).

## 3. Regularization with exactly preserved marginals

**定理 3.1（Finite entropy loss and quantitative recovery stability）。** For every pair of Definition 2.1 and $0\le e\le1$, put

$$
M(X)=I_E/m\otimes NX,\qquad F_e=(1-e)\mathrm{id}+e M,\qquad
Z_e=F_e(Z),\quad \rho_e=F_e(\rho).
$$

Then $NZ_e=P$, $N\rho_e=p$, and $Z_e\ge e\lambda_{\min}(P) I/m$. If $e>0$ and $p>0$, both joint states are faithful. With $Y_e=R_{Z_e}(p)$, $Y=R_Z(p)$, $n_e=\|\rho_e-Y_e\|_1$, $\Delta_e=D(\rho_e\Vert Z_e)-D(p\Vert P)$ and $K=P^{-1/2}pP^{-1/2}$, one has

$$
\begin{aligned}
0&\le\Delta_e\le (1-e)\Delta,\qquad \lim_{e\downarrow0}\Delta_e=\Delta,\\
L&=\sqrt{\operatorname{Tr}PK^2},\qquad
\|Y_e-Y\|_1\le 2L\sqrt{e\|MZ-Z\|_1},\\
|n_e-n|&\le e\|M\rho-\rho\|_1+2L\sqrt{e\|MZ-Z\|_1}
\le 2e+2\sqrt{2}L\sqrt e .
\end{aligned}
$$

The same recovery modulus holds for any two joint references $Z',Z$ with common faithful $P$ and any Hermitian retained matrix $x$, with $K=P^{-1/2}xP^{-1/2}$ and $\|Z'-Z\|_1$ in place of $e\|MZ-Z\|_1$.

Proof. The replacement map $M$ discards $E$ and prepares $I_E/m$. It is CPTP and $NM=N$. Joint convexity applies to the original supported pair and the replacement pair, for which the tensor-product logarithm gives $D(M\rho\Vert MZ)=D(p\Vert P)$. Subtracting the common output entropy proves the upper bound, and data processing proves the lower bound, also when $p$ is singular. Lower semicontinuity follows by taking the supremum over $a\downarrow0$ of $\operatorname{Tr}X\log X-\operatorname{Tr}X\log(\max(T,aI))$ for $D(X\Vert T)$ on densities. These expressions are continuous and increase to the support-aware entropy by diagonalizing $T$. Thus $\liminf\Delta_e\ge\Delta$, giving convergence.

For positive semidefinite $A,B$, set $U=\sqrt A,V=\sqrt B,D=U-V,W=\operatorname{sign}D$. Since $A-B=UD+DV$, cyclicity gives $\operatorname{Tr}W(A-B)=\operatorname{Tr}|D|(U+V)\ge\operatorname{Tr}D^2$ in an eigenbasis of $D$, using nonnegative diagonal entries of $U,V$. Trace norm duality gives $\|\sqrt A-\sqrt B\|_2^2\le\|A-B\|_1$, where $\|\cdot\|_2$ is the Hilbert–Schmidt norm. Now let $J=I_E\otimes K$, $S'=\sqrt{Z'}$, $S=\sqrt Z$. The identity $S'JS'-SJS=(S'-S)JS'+SJ(S'-S)$ and $\|JS'\|_2=\|SJ\|_2=L$ by the partial trace identity give the modulus by Schatten Hölder. Applying it to $Z_e$ and using the reverse triangle inequality for the residual yields the displayed bounds, independent of the joint rank and environment dimension except through the explicitly fixed marginal. For a density $p$, $0\le K\le\lambda_{\min}(P)^{-1}I$ and $\operatorname{Tr}PK=1$, so $L\le\lambda_{\min}(P)^{-1/2}$.

**推论 3.2（Retention of a strict finite-pair score）。** For every pair as in Definition 2.1 with $\Delta>0$ and $n^2/\Delta>c$ for a real $c\ge0$, let $\eta=n/\sqrt{\Delta}-\sqrt c>0$, $A=2+2\sqrt{2}L$. Every $0<e<1$ with $e\le\eta^2\Delta/(4A^2)$ satisfies $\Delta_e>0$ and $n_e^2/\Delta_e\ge(\sqrt c+\eta/2)^2/(1-e)>c$. For each fixed pair with positive finite loss the quotient converges to $n^2/\Delta$.

Proof. The error bound in Theorem 3.1 is at most $A\sqrt e\le\eta\sqrt\Delta/2$. Consequently $n_e\ge(\sqrt c+\eta/2)\sqrt\Delta>0$. The equality case of relative entropy data processing (Petz's equality theorem for supported pairs) implies $\Delta_e>0$. Apply the actual loss contraction and the two pointwise limits. If faithful sources are desired when $p$ is singular, mixing $\rho_e$ with $Z_e$ at a further sufficiently small positive proportion preserves a strict inequality, by continuity of entropy and the actual recovered state at fixed $e>0$. In that secondary mixture the marginal moves towards $P$.

## 4. Supported tangents and their finite-loss normalization

**定理 4.1（Transfer of the faithful tangent bound）。** For every joint reference $Z$ as in Definition 2.1, let $\Pi=\operatorname{supp}Z$, $H=H^\dagger=\Pi H\Pi$ with $\operatorname{Tr}H=0$ and $h=NH$. On the support define

$$
g_Z(H)=\int_0^\infty\operatorname{Tr}\left[H_\Pi(Z_\Pi+tI)^{-1}H_\Pi(Z_\Pi+tI)^{-1}\right]dt,\qquad G_Z(H)=g_Z(H)-g_P(h).
$$

For real sufficiently small $s$, $\rho_s=Z+sH$ is a supported density. Set $\Delta(s)=D(\rho_s\Vert Z)-D(P+sh\Vert P)$. Then

$$
\Delta(s)=\tfrac12 s^2 G_Z(H)+o(s^2),\qquad
\rho_s-R_Z(P+sh)=s(H-R_Z(h)).
$$

For $0<e\le1$, with $H_e=F_e(H)$ as in Theorem 3.1, one has $0\le G_{Z_e}(H_e)\le (1-e)G_Z(H)$ and $G_{Z_e}(H_e)\to G_Z(H)$. If $d=2$, the supported direction satisfies

$$
\|H-R_Z(h)\|_1^2\le\kappa(2\sqrt{\det P})G_Z(H).
$$

When $G_Z(H)>0$, the actual infinitesimal squared-score limit is therefore bounded by $2\kappa(2\sqrt{\det P})<6$.

Proof. On the support, $|s|\|Z_\Pi^{-1/2}H_\Pi Z_\Pi^{-1/2}\|_\infty<1$ suffices for positivity. Differentiating the trace entropy gives first derivative $\operatorname{Tr}H(\log Z_\Pi+I)$ and second derivative $\operatorname{Tr}H D\log_{Z_\Pi}[H]=g_Z(H)$ by the log resolvent formula. The output uses the same computation at faithful $P$. The first variations of both relative entropies vanish since the directions have trace zero. The residual identity follows from linearity. Apply the finite-loss contraction to $(Z+sH,Z)$, whose regularized source is $Z_e+sH_e$ with unchanged output. Divide by $s^2/2$ and let $s\to0$ for fixed $e$.

For energy convergence, $Z_e\ge(1-e)Z$ implies $\Pi(Z_e+tI)^{-1}\Pi\le((1-e)Z_\Pi+tI)^{-1}$ for $t>0$. For $e\le1/2$ the integrand with $H$ is dominated by $\|H\|_2^2/(\lambda_{\min}(Z_\Pi)/2+t)^2$ and converges by continuity of the inverse. The energy of $eMH$ is bounded by $e^2\|MH\|_2^2/(e\lambda_{\min}(P)/m)=O(e)$, and the mixed term by the BKM Cauchy–Schwarz inequality. Thus $g_{Z_e}(H_e)\to g_Z(H)$. Apply the accepted faithful theorem from Note 2.2 to $(Z_e,H_e)$ at the identical $P$. The Hermitian-direction recovery modulus in Theorem 3.1 and $H_e\to H$ allow passage to the limit. If $G_Z(H)=0$ the resulting residual vanishes. Otherwise the expansion yields the factor of two in the infinitesimal quotient. In particular the positive-marginal restriction is retained even for singular joint references.

## 5. Sharp regularity at a support boundary

**定理 5.1（Support/kernel crossing for arbitrary fixed faithful reference noise）。** Keep $Z,P$ as above, let $Q=I-\Pi$, and take any fixed faithful joint density $\tau>0$ with $N\tau=P$. For $0\le e\le1$ let $Z_e=(1-e)Z+e\tau$. For every Hermitian retained matrix $x$, set $J=I_E\otimes P^{-1/2}xP^{-1/2}$ and $T=Q\sqrt{(Q\tau Q)|_Q}Q$, extended by zero on $\Pi$ (zero if $Q=0$). Then in every fixed finite matrix norm

$$
\begin{aligned}
\sqrt{Z_e}&=\sqrt Z+\sqrt e\,T+O(e),\\
R_{Z_e}(x)-R_Z(x)&=\sqrt e\,(TJ\sqrt Z+\sqrt ZJT)+O(e),\\
\lim_{e\downarrow0}\frac{\|R_{Z_e}(x)-R_Z(x)\|_1}{\sqrt e}&=2\|TJ\sqrt Z\|_1 .
\end{aligned}
$$

The coefficient is positive exactly when $QJ\Pi\ne0$, equivalently $[J,\Pi]\ne0$. In that case the change has order $\Theta(\sqrt e)$, and in the zero-coefficient case it is $O(e)$. If $x>0$ and $Q\ne0$, the zero-coefficient case has order $\Theta(e)$.

Proof. Write the positive square root in support/kernel blocks as

$$
\sqrt{Z_e}=\begin{pmatrix}A_e&B_e\\B_e^\dagger&C_e\end{pmatrix},\qquad S_0=\sqrt{Z_\Pi}.
$$

The root modulus proves convergence to $S_0\oplus0$. Hence for sufficiently small $e$, $A_e\ge aI$ for some fixed $a>0$, and $C_e\ge0$. The off-diagonal equation obtained by squaring is $A_e B_e+B_e C_e=e\tau_{\Pi Q}$. The Sylvester map is invertible, because in separate eigenbases every coordinate is multiplied by an eigenvalue sum at least $a$. Its Hilbert–Schmidt inverse bound gives $B_e=O(e)$. The top equation gives $A_e^2-S_0^2=e(\tau_{\Pi\Pi}-Z_\Pi)-B_eB_e^\dagger=O(e)$. Apply the same argument to $A_e(A_e-S_0)+(A_e-S_0)S_0$ to get $A_e-S_0=O(e)$. The bottom equation $C_e^2=e\tau_{QQ}-B_e^\dagger B_e$ implies $(C_e/\sqrt e)^2=\tau_{QQ}+O(e)$. The Sylvester map with second factor $\sqrt{\tau_{QQ}}>0$ gives $C_e/\sqrt e=\sqrt{\tau_{QQ}}+O(e)$. When $Q=0$ only the top equation is needed.

The resulting root expansion gives the recovery expansion by multiplication. Its leading coefficient is Hermitian off-diagonal with trace norm $2\|TJ\sqrt Z\|_1$, by the paired positive and negative singular values of the off-diagonal blocks. The restrictions of $T$ to $Q$ and $\sqrt Z$ to $\Pi$ are invertible, proving the crossing equivalence. For $J>0$ the new recovery has $Q$-block trace $e\operatorname{Tr}(TJT)+O(e^{3/2})$ from these block estimates, with positive coefficient if $Q\ne0$. The old $Q$ block vanishes, giving the claimed lower bound by trace duality.

For the product noise of Theorem 3.1, $\rho_e-\rho=O(e)$, so the residual $\rho_e-R_{Z_e}(p)$ changes with the negative of the same leading coefficient. In the tangent family $Z+sH$ the exact identities $F_e(Z)=Z_e=R_{Z_e}(P)$ give a remainder $O(|s|e)$ after expanding the recovery of $h=NH$. These are pointwise fixed-reference boundary expansions. The uniform weighted modulus of Theorem 3.1 uses only the common marginal.

## 6. A rational two-qubit family and a fixed measurement

**命题 6.1（An actual sharp crossing at a fixed marginal）。** Take $E=B=\mathbb C^2$ and order the orthonormal basis as $(00,+,-,11)$ with $\psi_\pm=(01\pm10)/\sqrt2$ and $P_v=|v\rangle\langle v|$. Use

$$
\begin{aligned}
Z&=(P_{00}+P_+)/2,\quad H=P_+-P_{00},\quad \rho_s=Z+sH,\quad -1/2\le s\le1/2,\\
P&=\operatorname{diag}(3/4,1/4),\quad h=\operatorname{diag}(-1/2,1/2),\quad p_s=P+sh .
\end{aligned}
$$

The input matrices have rational computational-basis entries for rational $s$. For the product regularization and $Y_{s,e}=R_{Z_e}(p_s)$,

$$
\lim_{e\downarrow0}\|Y_{s,e}-Y_{s,0}\|_1/\sqrt e=(2\sqrt2/3)|s|.
$$

In particular the exponent $1/2$ is sharp at fixed $P$ and dimension four. On the same family $G_Z(H)=8/3$, $\Delta(s)=4s^2/3+o(s^2)$ and $\|H-R_Z(h)\|_1=4/3$.

Proof. Partial traces give the displayed $P,h$. On $\Pi=\operatorname{span}(00,+)$ the two weights of $\rho_s$ are $1/2-s,1/2+s$. Hence $g_Z(H)=4$ and $g_P(h)=(4/3+4)/4=4/3$. The tangent recovery on $\Pi$ is diagonal with entries $-1/3,1/3$. In the $(+,-)$ block the lifted likelihood $J_s=I_E\otimes P^{-1/2}p_sP^{-1/2}$ has off-diagonal entry $4s/3$. On the kernel, the compression of $\tau=I_E/2\otimes P$ is $\operatorname{diag}(1/4,1/8)$, so $TJ_s\sqrt Z=(2s/(3\sqrt2))|-\rangle\langle+|$. Theorem 5.1 gives the limit, and Theorem 4.1 gives the entropy expansion.

**定理 6.2（Fixed binary POVM and critical copy limit）。** On the same family let $W=|+\rangle\langle-|+|-\rangle\langle+|$ extended by zero, and measure the fixed POVM $\{(I+W)/2,(I-W)/2\}$ independently on each copy of the two joint hypotheses $\rho_{s,e}=F_e(\rho_s)$ and $Y_{s,e}$. For every sequence $e=e_N\in(0,1]$ tending to zero and $s=s_N\in[-1/2,1/2]$, with $N s_N^2 e_N\to\ell\in[0,\infty]$, the optimal equal-prior average measured error and optimal maximum conditional measured error converge to

$$
\Phi(-\sqrt{2\ell}/3)
$$

with $\Phi$ the standard normal CDF and the value zero at $\ell=\infty$.

Proof. The effects are positive and sum to $I$, as $\|W\|_\infty=1$. The middle block of $Z_e$ and its positive square root are

$$
M_e=\begin{pmatrix}1/2-e/4&-e/8\\-e/8&e/4\end{pmatrix},\qquad
d_e=\sqrt{e(8-5e)}/8,\qquad
\sqrt{M_e}=\begin{pmatrix}A&B\\B&C\end{pmatrix}=(M_e+d_e I)/\sqrt{1/2+2d_e}.
$$

The square identity follows from Cayley–Hamilton with $\operatorname{Tr}M_e=1/2$ and $\det M_e=d_e^2$, and positivity selects the root. In particular $AC-B^2=d_e$ and $B=-e/(8\sqrt{1/2+2d_e})$. Write $J=I_E\otimes P^{-1/2}hP^{-1/2}$. Its middle block is $(2/3)I+(4/3)W$. The reference cancels exactly from the difference $Y_{s,e}-\rho_{s,e}=s(R_{Z_e}(h)-H_e)$, and the off-diagonal entry of $H_e$ is $e/4$. The first effect has outcome probability $1/2$ plus the middle off-diagonal entry on these real densities. Multiplying the root blocks therefore gives the two first-outcome probabilities $u,v$ exactly,

$$
u=1/2-e/8+se/4,\qquad v-u=sf(e),\qquad f(e)=-e/3+(4/3)d_e+(8/3)B^2=(\sqrt2/3)\sqrt e+O(e).
$$

Thus $u,v\to1/2$ uniformly in the physical $s$ interval. Put $b_N=v-u$. For $0<\ell<\infty$, $I_N=Nb_N^2/[u(1-u)]\to I=8\ell/9$. The one-copy log likelihood of $v$ against $u$ takes values $\log(1+b_N/u)$ and $\log(1-b_N/(1-u))$. Taylor expansion gives means under the two hypotheses respectively $-b_N^2/(2u(1-u))+O(|b_N|^3)$ and $+b_N^2/(2u(1-u))+O(|b_N|^3)$, and variances $b_N^2/(u(1-u))+O(|b_N|^3)$. The remainders sum to zero in the limit and the centered increments are uniformly $O(|b_N|)$. The triangular-array Lindeberg theorem gives log likelihood limits $N(-I/2,I)$ and $N(I/2,I)$ (normal laws). The zero threshold likelihood test minimizes the equal-prior average error, and both conditional errors tend to $\Phi(-\sqrt I/2)$. The maximum conditional error is at least the optimal average error, yielding the same minimax limit. For $\ell=0$, the Bernoulli relative entropy is $O(b_N^2)$, so additivity and Pinsker give product total variation tending to zero. Random guessing attains the limit $1/2$ for both criteria. For $\ell=\infty$, the empirical mean threshold $(u+v)/2$ oriented by the sign of $v-u$ has both errors at most $1/(Nb_N^2)$ by Chebyshev. These proofs allow changing signs and vanishing perturbations.

## 7. Fixed versus noise-dependent blind measurements

**定理 7.1（Sharp repeated blind POVM constants）。** Use exactly the hypotheses of Theorem 6.2. A one-copy POVM is blind if it gives equal laws at $e=0$ for every physical $s$. Consider sequences with $s=s_N\to0$, $e=e_N\downarrow0$, and $Ns_N^2e_N\to\ell\in[0,\infty]$. Among all fixed finite blind POVMs repeated independently, the best limiting equal-prior and maximum conditional errors are $\Phi(-\sqrt{2\ell}/3)$. Among sequences of finite blind POVMs (arbitrary finite outcome counts) that may depend on $s,e,N$ and are repeated independently within each experiment, the sharp limits of the infima of these errors are $\Phi(-\sqrt\ell/2)$. A binary POVM depending only on $e$ attains the second limit. The constants are strictly distinct for $0<\ell<\infty$.

Proof. At $e=0$, $R_Z(h)-H=(2/3)(P_{00}-P_+)$. Consequently blindness is exactly equality of the $00$ and $++$ diagonals of every effect. Write an arbitrary effect's diagonal as $(a,a,b,c)$ and $z=\operatorname{Re}E_{+,-}$. Positivity and completeness give $|z|\le\sqrt{ab}$, $\sum a=\sum b=\sum c=1$ and $\sum z=0$. For each effect, write $p=\operatorname{Tr}E Z_e$, $g=\operatorname{Tr}E H_e$, and $d=\operatorname{Tr}E(R_{Z_e}(h)-H_e)$. From the matrices in Theorem 6.2 the two exact laws are $q=p+sg$, $r=q+sd$, where

$$
\begin{aligned}
p&=(1-3e/8)a+eb/4+ec/8-ez/4,&g&=e(c-a)/4+ez/2,\\
d&=\beta_e(b-a)+2f(e)z,&\beta_e&=e/6+(8/3)BC .
\end{aligned}
$$

Indeed the $--$ diagonal of the recovery derivative minus $H_e$ is $(2/3)(e/4)+(8/3)BC$, the $11$ entry is zero, and the trace is zero. The off-diagonal is $f(e)$ from Theorem 6.2. Here $B=O(e), C=O(\sqrt e)$, using its root block. In particular, with $k=2\sqrt2/3$,

$$
d=d_0+R,\qquad d_0=k\sqrt e\,z+eb/6,\qquad |R|\le C_0(ea+e^{3/2}(b+c)+e\sqrt{ab}).
$$

Let $p_*=a+eb/4+ec/8$. Rows with $p_*=0$ for $e>0$ are zero effects and can be omitted. By $|z|\le\sqrt{ab}$ and $\sqrt{eab}\le a+eb/4$, one has $q/p_*=1+O(\sqrt e+|s|)$, $|g|/p_*=O(1)$ and $|d|/q=O(1)$ uniformly for sufficiently small $e,|s|$. Squaring the remainder with the factor three bound and using $a^2/p_*\le a$, $(b+c)^2/p_*\le8(b+c)/e$, $ab/p_*\le b$ gives $\sum R^2/p_*=O(e^2)$. Weighted Cauchy–Schwarz gives

$$
|d_0|/\sqrt e\le\sqrt b(k\sqrt a+\tfrac13\sqrt{eb/4}),\qquad
d_0^2/(ep_*)\le b(k^2+1/9)=b.
$$

Thus, using Cauchy–Schwarz also on the mixed remainder, the squared score norm $J_{s,e}=\sum d^2/q$ obeys uniformly over all finite blind POVMs

$$
J_{s,e}/e=\sum d_0^2/(ep_*)+O(\sqrt e+|s|)\le1+O(\sqrt e+|s|).
$$

In a fixed finite POVM, rows with $a>0$ contribute $k^2z^2/a\le(8/9)b$ in the limit. Rows with $a=0$ have $z=0$ and contribute $(b/6)^2/(b/4+c/8)\le b/9$. Hence

$$
J_{s,e}/e\longrightarrow I(M)=k^2\sum_{a>0}z^2/a+\sum_{a=0}\frac{(b/6)^2}{b/4+c/8}\le8/9,
$$

with the zero row interpreted as zero. The fixed effects $(I\pm W)/2$ attain $8/9$ since both have $a=b=c=1/2$ and $z=\pm1/2$.

For the moving test, choose $\theta\in(0,\pi/2)$ with $\tan^2\theta=2e$, $v=\cos\theta\,\psi_-+\sin\theta\,\psi_+$. The effect $E=P_v+\sin^2\theta\,P_{00}$ and its complement form a blind POVM, since the two projectors in $E$ have orthogonal supports. For $E$, $(a,b,c,z)=(2e,1,0,\sqrt{2e})/(1+2e)$. The rare outcome has $q\sim9e/4$ and $d\sim3e/2$, by the exact formulas and $s\to0$. Its complement has $q\to1$ and opposite $d$. Hence $J_{s,e}/e\to1$.

For any sequence of repeated blind POVMs the relative increment $\zeta=sd/q$ under the source law has mean zero, variance $V=s^2J_{s,e}$ and $|\zeta|=O(|s|)$ uniformly. The log likelihood increment $\log(1+\zeta)$ has mean $-V/2+O(|s|V)$, second moment $V+O(|s|V)$ and third absolute moment $O(|s|V)$. Under the recovery law, weighting each expectation by $1+\zeta$ changes the mean to $V/2+O(|s|V)$ and preserves the second moment estimate. For a subsequence with $J_{s,e}/e\to I$ and finite $\ell$, the summed log likelihood converges under the two hypotheses to normal laws with means $\mp\ell I/2$ and variance $\ell I$ when $\ell I>0$, by Lindeberg and the uniform vanishing increment bound. If $\ell I=0$, the source log likelihood tends to zero in probability from its mean and variance. The optimal average error is $\tfrac12\mathbb E_q\min(1,\exp L_N)$, where $L_N$ is the summed log likelihood, so bounded continuity gives $\Phi(-\sqrt{\ell I}/2)$ in both cases. When $\ell I>0$ the two conditional threshold errors have that limit, and for $\ell I=0$ random guessing suffices for the maximum conditional criterion. Every sequence has such subsequences because the coefficients $J_{s,e}/e$ are bounded, with all accumulation points at most one (and at most $8/9$ for each fixed finite POVM). This proves the lower bounds including for a sequence approaching the infima. The displayed attaining POVMs give the matching limits. For $\ell=\infty$ and either attaining POVM, the repeated score $d/q$ has source mean zero and variance $J_{s,e}$, recovery mean $sJ_{s,e}$ and variance at most $(1+O(|s|))J_{s,e}$. The mean-score threshold $sJ_{s,e}/2$, oriented by the sign of $s$, has conditional errors $O(1/(Ns^2J_{s,e}))\to0$. This finishes both endpoint cases as well.

## 8. Outstanding global problem and sources

**开放问题 8.1（The ordinary finite-displacement constant）。** For retained qubit dimension define $C(2)$ as the supremum of $\|\rho-R_Z(p)\|_1^2/\Delta$ over the supported pairs of Definition 2.1 with $\Delta>0$, allowing every finite nonzero environment dimension. The same supremum describes all finite CPTP maps $\mathcal N$ with output reference rank two, using the inverse on that output support and ordinary recovery $\sqrt Z\,\mathcal N^\dagger((\mathcal NZ)^{-1/2}(\mathcal N\rho)(\mathcal NZ)^{-1/2})\sqrt Z$. Indeed a Stinespring isometry $V$ with $\mathcal N(X)=\operatorname{Tr}_E(VXV^\dagger)$ sends the input support into $E\otimes\operatorname{supp}(\mathcal NZ)$: the expectation of the complementary output projection in $VZV^\dagger$ is zero. It preserves both relative entropies, and the joint recovery is exactly the isometric image of the original recovery by $V^\dagger(I_E\otimes A)V=\mathcal N^\dagger(A)$. Thus it preserves the full trace norm of the residual. Partial traces are themselves CPTP, giving equality of the two suprema. The ordinary assertion $C(2)=6$ remains open. Theorem 3.1 and Corollary 3.2 reduce a strict finite-pair violation to faithful references, preserving the individual marginals in the first regularization. Theorem 4.1 bounds the common-reference infinitesimal quotient. Establishing a global sharp finite-displacement bound would require controlling the actual recovery and entropy along finite displacements, including unbounded environment dimensions. The boundary experiment of Sections 6–7 quantifies a different observable, the blind measured decision error for one fixed physical family.

The literature inputs used in the proofs are joint convexity and data processing of quantum relative entropy, Petz's equality theorem, Schatten Hölder, the resolvent identity for the log derivative, and the Lindeberg central limit theorem. The fixed-marginal identities, boundary expansions, and measured asymptotics are repo-derived ordinary proofs. The two independent symbolic replays checked the partial traces, root square identity, signed recovery entries, crossing coefficient, BKM coefficient and binary Fisher limits $8/9$ and $1$. The quantification over arbitrary finite matrix sizes and the statistical limits follow from the proofs. Formal acceptance of the faithful theorem and its consumers is pinned in Note 2.2.

## 追加锚（本行以下为增补区）

## 9. Weighted environment truncation and finite-copy testing

This supplement extends the finite-displacement problem in Section 8 by comparing actual ordinary Petz outputs under a specified environment compression and by exhibiting its two-qubit obstruction.

**定理 9.1（Weighted kept-block Sylvester transport）。** Let $\rho,\sigma$ be joint densities on finite nonzero $E\otimes B$ with $\operatorname{supp}\rho\subseteq\operatorname{supp}\sigma$. In this section write $T=\operatorname{Tr}_E$, $P=T\rho$, $Q=T\sigma$, $L=Q^{-1/2}PQ^{-1/2}$ and $M=I_E\otimes L$. Restrict $B$ to $\operatorname{supp}Q$, so $Q>0$. The actual recovered density is $Y=\sqrt\sigma M\sqrt\sigma$. For any orthogonal projection $J$ on $E$ and $K=I_E-J$, use their lifts by $I_B$ and the channel $\Phi$ to $JE\oplus\mathbb C f$ given by

$$
\Phi(W)=JWJ\oplus\operatorname{Tr}_{KE}(KWK).
$$

Put $\rho'=\Phi(\rho)$, $\sigma'=\Phi(\sigma)$ and let $Y'$ be the ordinary Petz output from $\sigma'$ and the actual retained marginal of $\rho'$. Write $r=\|\rho-Y\|_1$, $r'=\|\rho'-Y'\|_1$ and the actual deficits $\Delta=D(\rho\Vert\sigma)-D(P\Vert Q)$ and $\Delta'=D(\rho'\Vert\sigma')-D(P\Vert Q)$. Use the common environment $JE\oplus KE\oplus\mathbb C f$, extending the respective states by zero. In the original two blocks write

$$
S=\sqrt\sigma=\begin{pmatrix}H&G\\G^\dagger&C\end{pmatrix},\quad
D=\sqrt{H^2+GG^\dagger},\quad F=\sqrt{\operatorname{Tr}_{KE}(C^2+G^\dagger G)},\quad X=D-H.
$$

Use $A_J=I_{JE}\otimes\sqrt L$, $A_K=I_{KE}\otimes\sqrt L$, $A_f=\sqrt L$, with $\sqrt M$ lifted to the common space. Define $x=\|XA_J\|_2$, $t=\operatorname{Tr}(MK\sigma)$, $b=\|G^\dagger A_J\|_2^2$, and $a=\|S\sqrt M-\sqrt{\sigma'}\sqrt M\|_2$ in that space. Then

$$
\begin{aligned}
a^2&=x^2+2t+b,&\|Y-Y'\|_1&\le\min(2,2a),\\
DX+XH&=GG^\dagger,&HX+XH+X^2&=GG^\dagger,\\
XA_J&=\int_0^\infty e^{-sD}GG^\dagger e^{-sH}A_J\,ds .
\end{aligned}
$$

These identities include singular kept blocks. Writing $V=XA_J$, its weighted Sylvester equation is $DV+VH=GG^\dagger A_J+X[A_J,H]$. For $c=\|[A_J,H]\|_2$, $\kappa=\|L\|_\infty$ and $w_\sigma=\operatorname{Tr}(K\sigma)$, one has

$$
x\le c/\sqrt2+\sqrt{b+c^2/2},\qquad x^2\le\kappa\|G\|_2^2,\qquad a^2\le4\kappa w_\sigma.
$$

Proof. Support containment implies $\rho\le c_0\sigma$ for some finite $c_0$, so both retained marginals are supported on $Q$ and $\rho'\le c_0\sigma'$. The environment Kraus operators of $\Phi$ are the kept inclusion composed with $J$ and the operators $|f\rangle\langle k|$ for an orthonormal basis of $KE$. Their adjoint products sum to $I_E$. Summing the two diagonal environment marginals preserves $P,Q$ exactly, so the likelihood $L$ is common. The compressed square root is $D\oplus0\oplus F$ on the common space. The amplitudes $U=S\sqrt M$ and $U'=\sqrt{\sigma'}\sqrt M$ give $Y=UU^\dagger$, $Y'=U'U'^\dagger$, both with squared Hilbert–Schmidt norm of the amplitude equal to $\operatorname{Tr}(LQ)=1$. The discarded column contributes $t=\|GA_K\|_2^2+\|CA_K\|_2^2$, the off-diagonal discarded row contributes $b$, and the flag contributes $\|FA_f\|_2^2=t$. The full discarded row weight is $\operatorname{Tr}(KY)=b+\|CA_K\|_2^2$. Including the kept block gives the stated squared amplitude identity. Factoring the difference of the two amplitude products and using Schatten Hölder gives the trace bound.

Square-root monotonicity gives $D\ge H\ge0$. Expand $D^2-H^2=GG^\dagger$ to obtain the two Sylvester identities. In separate eigenbases for $D,H$, the coefficient of the first Sylvester map is $d+h$ for eigenvalues $d,h\ge0$. At $d=h=0$ the corresponding block of $X$ vanishes since $\ker D\subseteq\ker H$ and $X$ annihilates $\ker D$. Integration of $e^{-s(d+h)}$ on the positive-sum blocks proves the formula. Multiplying the first identity by $A_J$ on the right and commuting $A_J$ across $H$ gives the weighted equation.

For the estimates let $A=A_J$. Taking the trace of the quadratic identity against $A^2$ and expanding the double commutator gives

$$
x^2=b-2\operatorname{Tr}(XAHA)-\operatorname{Tr}([X,A][A,H]).
$$

The middle trace is nonnegative. Since $X,A\ge0$, the trace $\operatorname{Tr}(AXAX)$ is nonnegative and $\|[X,A]\|_2^2=2x^2-2\operatorname{Tr}(AXAX)\le2x^2$. Cauchy–Schwarz gives $x^2\le b+\sqrt2 cx$ and solving the quadratic yields the first estimate. The unweighted trace gives $\|X\|_2^2\le\|G\|_2^2$. Also $t\le\kappa w_\sigma$ and $b\le\kappa\|G\|_2^2\le\kappa w_\sigma$ because the discarded diagonal block of $\sigma$ is $C^2+G^\dagger G$. Substituting into the amplitude identity gives the final estimate.

**命题 9.2（Vanishing weighted tails with a strict change of actual recovery）。** There is a supported two-qubit pair with joint reference of rank three and $Q\ge(3/16)I$, and with the compressor of Theorem 9.1, for which $t=b=w_\rho=0$ with $w_\rho=\operatorname{Tr}(K\rho)$. Nevertheless $x>0$, $\Phi(Y)=Y$ under the common embedding, and $Y'\ne Y$. Its actual residual decreases strictly under the compression. There is a family of faithful joint pairs approaching this example through the same compressor, with $t,b,w_\rho=O(\epsilon^2)$ and $Q_\epsilon\ge(3/32)I$ for $0<\epsilon<1$, for which the recovery gap tends to a positive value. Both original and compressed entropy defects are positive in the limit and their squared scores are below one.

Proof. Take $E=B=\mathbb C^2$, with $J=|0\rangle\langle0|$ on $E$ and retained coordinates $e_0,e_1$. Set

$$
H_0=\begin{pmatrix}2&1\\1&2\end{pmatrix},\quad
G_0=\operatorname{diag}(0,1),\quad C_0=\operatorname{diag}(0,2),\quad
S_0=\begin{pmatrix}H_0&G_0\\G_0&C_0\end{pmatrix},\quad \sigma=S_0^2/16.
$$

The kernel of $S_0$ is spanned by $|1\rangle\otimes e_0$. On the complementary coordinates $(00,01,11)$ it is tridiagonal with diagonal $2$ and adjacent entries $1$, hence has eigenvalues $2+\sqrt2,2,2-\sqrt2$. Thus $\sqrt\sigma=S_0/4$ and $\operatorname{Tr}\sigma=1$. The kept block of $S_0^2$ is $A_0=\begin{pmatrix}5&4\\4&6\end{pmatrix}$, the discarded block is $\operatorname{diag}(0,5)$, and $Q=Q_0/16$ with $Q_0=\begin{pmatrix}5&4\\4&11\end{pmatrix}$ of eigenvalues $13,3$. For a unit vector $z$ write $P_z=|z\rangle\langle z|$. Put $v=\sqrt{Q_0}e_0/\sqrt5$ and $\rho=P_{|0\rangle\otimes v}$. It is supported in $\sigma$ and $P=P_v$, $L=(16/5)P_{e_0}$. Both weighted tails vanish since $G_0,G_0^\dagger,C_0$ annihilate $e_0$. The two recovered states have kept unit vectors $h=H_0 e_0/\sqrt5$ and $d=\sqrt{A_0}e_0/\sqrt5$. If $Xe_0=0$, Hermiticity gives $X=\operatorname{diag}(0,u_0)$ and the $01$ coordinate of $HX+XH+X^2=GG^\dagger$ forces $u_0=0$ since $H_{01}=1/4$. This contradicts $GG^\dagger\ne0$.

For any positive definite two-by-two matrix $A$, Cayley–Hamilton verifies $\sqrt A=(A+\sqrt{\det A}I)/\sqrt{\operatorname{Tr} A+2\sqrt{\det A}}$. Consequently the respective slopes of $v,h,d$ are $\alpha,1/2,\beta$, where

$$
\alpha=4/(5+\sqrt{39}),\qquad \beta=4/(5+\sqrt{14}),\qquad 0<\alpha<\beta<1/2.
$$

Two real unit vectors of slopes $u,v_1$ and positive first coordinates have pure-state trace distance $R(u,v_1)=2|u-v_1|/\sqrt{(1+u^2)(1+v_1^2)}$, by diagonalizing the difference on their span. Increasing the angle $\arctan s-\arctan\alpha$ for $\alpha<s\le1/2$ proves $r=R(\alpha,1/2)>r'=R(\alpha,\beta)$. The actual output gap is $R(\beta,1/2)$ and $x^2=2-2(1+\beta/2)/\sqrt{(1+1/4)(1+\beta^2)}$.

For the exact defects set $u=(1+\alpha^2)^{-1/2}$, $v_1=\alpha u$, $k_\pm=(11\pm\sqrt{65})/2$, and $p_*=(5u^2+8uv_1+6v_1^2-k_-)/(k_+-k_-)$. The log expectations at the pure vector are

$$
\begin{aligned}
m&=(13\log13+12\log3)/25,\\
s&=(u/2+v_1/\sqrt2)^2\log((2+\sqrt2)^2)+(u^2/2)\log4
 +(u/2-v_1/\sqrt2)^2\log((2-\sqrt2)^2),\\
s'&=p_*\log k_++(1-p_*)\log k_- .
\end{aligned}
$$

Indeed the $e_0$ weights on the eigenspaces of $Q_0$ are $1/5,4/5$, which become $13/25,12/25$ in $v$. The three reference weights are the squared overlaps with $(1/2,\pm1/\sqrt2,1/2)$ and $(1/\sqrt2,0,-1/\sqrt2)$, and $p_*$ is the $k_+$ weight for $A_0$. Purity cancels the source entropies and the normalization logarithms cancel between the reference and its marginal. Thus $\Delta=m-s$ and $\Delta'=m-s'$. The pinned directed interval replay of these exact expressions gives

$$
\begin{aligned}
r&\in(0.2431802107,0.2431802108),&r'&\in(0.1745435495,0.1745435496),\\
r-r'&\in(0.0686366611,0.0686366612),&\|Y-Y'\|_1&\in(0.0690038604,0.0690038605),\\
\Delta&\in(0.0731558158,0.0731558159),&\Delta'&\in(0.0455696576,0.0455696577),\\
r^2/\Delta&\in(0.8083651886,0.8083651888),&r'^2/\Delta'&\in(0.6685468418,0.6685468419),\\
x^2&\in(0.0011907376,0.0011907377).
\end{aligned}
$$

For faithful approximation let $z_\epsilon^2=\|S_0+\epsilon I\|_2^2=16+12\epsilon+4\epsilon^2$, $\sigma_\epsilon=(S_0+\epsilon I)^2/z_\epsilon^2$, $Q_\epsilon=T\sigma_\epsilon$, $v_\epsilon=\sqrt{Q_\epsilon}e_0/\sqrt{(Q_\epsilon)_{00}}$, and $\delta=\epsilon^2$. Put $\rho_\epsilon=(1-\delta)P_{|0\rangle\otimes v_\epsilon}+\delta\sigma_\epsilon$. Both states are faithful for $0<\epsilon<1$. Their actual likelihood is $(1-\delta)P_{e_0}/(Q_\epsilon)_{00}+\delta I$. In particular $Q_\epsilon\ge Q_0/z_\epsilon^2\ge(3/32)I$, with least eigenvalue tending to $3/16$. Substitution gives

$$
\begin{aligned}
w_{\sigma,\epsilon}&=(5+4\epsilon+2\epsilon^2)/z_\epsilon^2,& w_{\rho,\epsilon}&=\delta w_{\sigma,\epsilon},\\
t_\epsilon&=(1-\delta)\epsilon^2/(5+4\epsilon+2\epsilon^2)+\delta w_{\sigma,\epsilon},&
b_\epsilon&=\delta/z_\epsilon^2.
\end{aligned}
$$

The compressor preserves the two retained marginals for each $\epsilon$, and these marginals may vary with $\epsilon$. Continuity of square roots and the retained inverse gives convergence of the recoveries and residuals. In the logarithm expectation the pure source component lies in the fixed positive spectral subspace of $S_0$, where the reference logarithms converge, and in the uniformly positive kept block after compression. The reference-mixture term contributes $\delta\operatorname{Tr}(\sigma_\epsilon\log\sigma_\epsilon)$ and its compressed counterpart, both tending to zero. Source entropies and retained terms are continuous. Hence both defects and both squared scores converge. This family rules out a modulus tending to zero in the weighted tails $t,b$ even with $w_\rho$ included, at the stated dimensions and marginal floor, for this compressor.

**定理 9.3（Same-copy simulation and strict Bayes gap）。** Under Theorem 9.1 let $N\ge1$ be any finite integer. Define the decoder from $JE\oplus\mathbb C f$ to $E$ by keeping the kept block and replacing the flag by a fixed density on $KE$ while retaining its retained-system marginal. If $K=0$, decode the unused flag to any fixed environment density. The prescribed product channels $\Phi^{\otimes N}$ and the product decoder compare the triples $(\rho^{\otimes N},\sigma^{\otimes N},Y^{\otimes N})$ and $((\rho')^{\otimes N},(\sigma')^{\otimes N},(Y')^{\otimes N})$ with worst per-hypothesis unhalved trace error in either direction bounded by

$$
\min\big(2,\,2\sqrt{N\max(2w_\rho,2w_\sigma,a^2)}\big).\tag{9.1}
$$

For the binary experiment $(\rho,Y)$ use $\max(2w_\rho,a^2)$ in this expression. These are bounds for the specified product maps, hence also upper bounds for the respective optimal errors when the processing is optimized over all CPTP maps. Each collective POVM event has simulation error at most half the corresponding trace error.

In Proposition 9.2 the equal-prior optimal Bayes error strictly increases for every finite $N\ge1$. Writing

$$
r_N=2\sqrt{1-|\langle v,h\rangle|^{2N}},\qquad
r'_N=2\sqrt{1-|\langle v,d\rangle|^{2N}},
$$

the increase is $(r_N-r'_N)/4>0$. Every reverse CPTP simulation of this binary pair has maximum per-hypothesis unhalved trace error at least $(r_N-r'_N)/2$. The prescribed forward compressor has exact benchmark error $2\sqrt{1-|\langle h,d\rangle|^{2N}}$. For each fixed $N$, the strict Bayes gap persists for sufficiently small positive $\epsilon$ in the faithful family of Proposition 9.2.

Proof. Write $f(A,B)=\|\sqrt A\sqrt B\|_1$ for root fidelity. For $W=\rho,\sigma$ the compressed and decoded densities both dominate $JWJ$ in the relevant common embedding. Since $\sqrt W JWJ\sqrt W=(\sqrt W J\sqrt W)^2$, monotonicity of the square root gives root fidelity at least $1-w_W$ with $W$. The source and reference forward simulations are exact. For the actual benchmarks the normalized amplitudes of Theorem 9.1 have real Hilbert–Schmidt overlap $1-a^2/2$. Vectorizing them gives purifications, so $f(Y,Y')\ge g=(1-a^2/2)_+$. The common-space extensions of the compressor and decoder dephase between $E$ and the flag, then respectively fix the flag and fix $E$. They therefore fix the corresponding embedded target states. Contractivity bounds the benchmark errors in both directions by the common-space distance of the tensor powers. Multiplicativity of root fidelity and the fidelity–trace inequality yield the reverse source and reference bounds $2\sqrt{1-(1-w_W)^{2N}}$ and the two benchmark bounds $2\sqrt{1-g^{2N}}$. Using $1-(1-u)^N\le Nu$ for $0\le u\le1$ gives (9.1), with the trivial upper bound $2$. The event estimate follows from trace duality for effects. At bounded $N\Delta$, the binary error bound tends to zero along any family with positive $\Delta$ and $w_\rho+a^2=o(\Delta)$.

For the example the angle order from Proposition 9.2 gives $0<|\langle v,h\rangle|<|\langle v,d\rangle|<1$. The pure-state trace formula and tensor-product overlaps give $r_N>r'_N$ for every finite $N\ge1$. By the Helstrom formula the two optimal equal-prior errors are $1/2-r_N/4$ and $1/2-r'_N/4$. If a reverse CPTP map has maximum per-hypothesis trace error $q$, then trace contractivity and the triangle inequality imply $r_N\le r'_N+2q$. The forward formula follows because the specified compressor fixes both kept pure densities. At each fixed copy number continuity of the tensor-product densities and trace norms gives the strict faithful gap.

### 9.4 Sources and scope

The three results are repo-derived ordinary proofs from “Weighted ordinary Petz comparison for a projection and external flag” (25 November 2026), independently approved in the sshx review with run ID `37c949e5411f902b6ac0d741`. The pinned research artifacts in `petz-weighted-environment-truncation-proof` are `proof.txt` (SHA-256 `49341ee6e760de214eaf38978895658bfc174b28142edcc7401cdfba69ba2654`), `replay.py` (SHA-256 `2301116be5102ed4a6d668ba4b8ece532d91d03fdb8804af7ecc84d897cafd67`) and `independent-review-result.json` (SHA-256 `c899a5155e527aaba841474188b5be7816251d5ec55810871358883c7b0d082d`). The exact scalar replay `python3 -I -B replay.py` passed all nine open intervals using 55-digit directed Decimal arithmetic, enclosing the correctly rounded square roots and logarithms by adjacent decimals. The fidelity and Helstrom formulas used in Theorem 9.3 are standard quantum testing identities. The scope of (9.1) is equation (7) of the approved proof. Both squared scores in the witness are strictly below one. The bounded-dimension compression question for a strict margin above squared score six and the assertion $C(2)=6$ remain open.

## 追加锚（本行以下为增补区）
